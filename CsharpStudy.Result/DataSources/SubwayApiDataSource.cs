using CsharpStudy.Result.DTOs;
using Newtonsoft.Json;

namespace CsharpStudy.Result.DataSources;

public class SubwayApiDataSource : ISubwayApiDataSource
{
    private const string BaseUrl = "http://swopenapi.seoul.go.kr/api/subway/sample/json/realtimeStationArrival/0/5/";
    private HttpClient _httpClient;

    public SubwayApiDataSource(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Response<SubwayDto>> GetSubwayAsync(string subwayName)
    {
        var response = await _httpClient.GetAsync($"{BaseUrl}/{subwayName}");

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