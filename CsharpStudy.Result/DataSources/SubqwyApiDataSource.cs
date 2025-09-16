using CsharpStudy.Result.Dtos;
using Newtonsoft.Json;

namespace CsharpStudy.Result.DataSources;

public class SubqwyApiDataSource : ISubwayApiDataSource
{
    private const string BaseUrl = "string requestUrl = $\"http://swopenapi.seoul.go.kr/api/subway/sample/json/realtimeStationArrival/0/5";
    private HttpClient _httpClient;

    public SubqwyApiDataSource(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }


    public async Task<Response<SubwayDto>> GetSubwayAsync(string stationName)
    {
        // 한글 역명 URL 인코딩
        string encodedStationName = System.Web.HttpUtility.UrlEncode(stationName);   
        var response = await _httpClient.GetAsync($"{BaseUrl}/{stationName}");

        var jsonString = await response.Content.ReadAsStringAsync();

        var headers = response.Headers.ToDictionary(
            header => header.Key,
            header => string.Join(", ", header.Value)
        );

        return new Response<SubwayDto>(
            statusCode: (int)response.StatusCode,
            headers: headers,
            body: JsonConvert.DeserializeObject<SubwayDto>(jsonString)!
        );
    }
}