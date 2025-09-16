using System.Net.Http;
using System.Text.Json;

class Program
{
    // 개인 키 있으면 sample 대신 교체
    const string ApiKey = "sample";
    static readonly HttpClient http = new() { Timeout = TimeSpan.FromSeconds(7) };

    static async Task Main(string[] args)
    {
        string station = args.Length > 0 ? args[0] : "서울";
        try
        {
            string url = $"http://swopenapi.seoul.go.kr/api/subway/{ApiKey}/json/realtimeStationArrival/0/5/{Uri.EscapeDataString(station)}";
            using var res = await http.GetAsync(url);
            res.EnsureSuccessStatusCode();

            using var s = await res.Content.ReadAsStreamAsync();
            using var doc = await JsonDocument.ParseAsync(s);
            var root = doc.RootElement;

            // API 에러 상태 체크 (status != 200)
            if (root.TryGetProperty("errorMessage", out var em) &&
                em.TryGetProperty("status", out var statusEl) &&
                statusEl.GetInt32() != 200)
            {
                Console.WriteLine($"역 이름을 다시 확인하세요: {station}");
                return;
            }

            if (!root.TryGetProperty("realtimeArrivalList", out var list) || list.GetArrayLength() == 0)
            {
                Console.WriteLine($"'{station}' 역의 도착 정보가 없습니다.");
                return;
            }

            Console.WriteLine($"[실시간 도착] {station}");
            foreach (var e in list.EnumerateArray())
            {
                string updn = e.GetPropertyOrDefault("updnLine");
                string line = e.GetPropertyOrDefault("trainLineNm");
                string msg  = e.GetPropertyOrDefault("arvlMsg2");
                string sec  = e.GetPropertyOrDefault("barvlDt"); // 초
                Console.WriteLine($"- ({updn}) {line} | {msg} | {sec}s");
            }
        }
        catch
        {
            Console.WriteLine("조회 중 오류가 발생했습니다.");
        }
    }
}

static class JsonExt
{
    public static string GetPropertyOrDefault(this JsonElement el, string name)
        => el.TryGetProperty(name, out var v) && v.ValueKind != JsonValueKind.Null
           ? v.ToString()
           : "";
}
