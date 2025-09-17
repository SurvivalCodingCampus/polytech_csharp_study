using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Subway.Models;

namespace Subway.Data;

public class RemotePostDataSource : ISubwayApiDataSource
{
    private const string BaseUrl = "http://swopenapi.seoul.go.kr/api/subway/sample/json/realtimeStationArrival/0/5/";
    private HttpClient _httpClient;
    
    public RemotePostDataSource(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    
    public async Task<BarvlDt> GetPokemonAsync(string subwayName)
    {
        var resp = await _httpClient.GetAsync($"{BaseUrl}/{subwayName}");
        if (!resp.IsSuccessStatusCode) return null; // 통신안되면 null

        var json = await resp.Content.ReadAsStringAsync();
        var jo = JObject.Parse(json); // Newtonsoft.Json (Json.NET) 라이브러리에서 제공하는 동적 JSON 객체 타입
        
        return new BarvlDt(jo["realtimeArrivalList"]?[0]?["arvlMsg3"]?.ToString()); //arvlMsg3 이게 목적지
    }
}