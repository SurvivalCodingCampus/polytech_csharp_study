using Newtonsoft.Json;

namespace CsharpStudy.Subway.DataSources;

public class SeoulStationApiDataSource : ISeoulStationApiDataSource
{
    private const string BaseUrl = "http://swopenapi.seoul.go.kr/api/subway/sample/json/realtimeStationArrival/0/5";
    
    private HttpClient _httpClient;

    public SeoulStationApiDataSource(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<Response<SeoulStationDto>> GetSeoulStationAsync(string stationName)
    {
        var response =await _httpClient.GetAsync($"{BaseUrl}/{stationName}");
        var jsonString = await response.Content.ReadAsStringAsync();
        
        var headers = response.Headers.ToDictionary(
            header => header.Key,
            header => string.Join(",", header.Value)
            );

        return new Response<SeoulStationDto>(
            statusCode: (int)response.StatusCode,
            headers: headers,
            body: JsonConvert.DeserializeObject<SeoulStationDto>(jsonString)!
        );
    }
}