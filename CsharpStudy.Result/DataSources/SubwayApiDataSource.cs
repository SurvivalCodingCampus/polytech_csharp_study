using System.Web;
using CsharpStudy.Result.Dtos;
using Newtonsoft.Json;

namespace CsharpStudy.Result.DataSources;

public class SubwayApiDataSource : ISubwayApiDataSource
{
    private const string BaseUrl = "http://swopenAPI.seoul.go.kr/api/subway/sample/json/realtimeStationArrival/0/5";
    private readonly HttpClient _httpClient;

    public SubwayApiDataSource(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Response<ApiResponseDto>> GetSubwayAsync(string stationName)
    {
        string encodedStationName = HttpUtility.UrlEncode(stationName);
        var requestUrl = $"{BaseUrl}/{encodedStationName}";

        var httpResponse = await _httpClient.GetAsync(requestUrl);
        var jsonString = await httpResponse.Content.ReadAsStringAsync();

        var headers = httpResponse.Headers.ToDictionary(
            header => header.Key,
            header => string.Join(", ", header.Value)
        );

        // ApiResponseDto로 역직렬화
        return new Response<ApiResponseDto>(
            statusCode: (int)httpResponse.StatusCode,
            headers: headers,
            body: JsonConvert.DeserializeObject<ApiResponseDto>(jsonString) ?? throw new InvalidOperationException()
        );
    }
}