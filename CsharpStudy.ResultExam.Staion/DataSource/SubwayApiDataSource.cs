using CsharpStudy.ResultExam.SubwayExam.DTO;
using Newtonsoft.Json;

namespace CsharpStudy.ResultExam.SubwayExam.DataSource;

public class SubwayApiDataSource : ISubwayApiDataSource
{
    private const string BaseUrl =
        "http://swopenapi.seoul.go.kr/api/subway/sample/json/realtimeStationArrival/0/5/"; // PokeAPI의 기본 URL을 상수로 정의합니다. > "서울", "ditto" 등은 뺀 BaseUrl

    private HttpClient _httpClient; // HTTP 요청을 보내기 위한 HttpClient 인스턴스입니다.

    public SubwayApiDataSource(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Response<SubwayArrivalDto>> GetSubwayArrivalAsync(string stationName) // statnNm
    {
        var response =
            await _httpClient.GetAsync($"{BaseUrl}/{stationName}"); // GetAsync를 사용하여 비동기적으로 API에 GET 요청을 보냅니다.
        var jsonString = await response.Content.ReadAsStringAsync(); // 응답 본문을 문자열(JSON) 형태로 비동기적으로 읽어옵니다.

        // 응답 헤더를 Dictionary 형태로 변환하여 저장합니다.
        var headers = response.Headers.ToDictionary(
            header => header.Key,
            header => string.Join(", ", header.Value)
        );

        // 최종적으로 상태 코드, 헤더, 그리고 JSON 문자열을 SubwayArrivalDto 역직렬화한 본문을 담은
        // Response 객체를 생성하여 반환합니다.
        return new Response<SubwayArrivalDto>(
            statusCode: (int)response.StatusCode,
            headers: headers,
            body: JsonConvert.DeserializeObject<SubwayArrivalDto>(jsonString)!
            // JsonConvert.DeserializeObject를 사용해 JSON 문자열을 SubwayArrivalDto 객체로 변환합니다.
            // '!'는 이 결과가 null이 아님을 컴파일러에게 알려주는 것입니다.
        );
    }
}