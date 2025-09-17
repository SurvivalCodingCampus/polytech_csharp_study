using CsharpStudy.SubwayAPI.Data.Common;
using Newtonsoft.Json;

namespace CsharpStudy.SubwayAPI.Data.DataSources;

public class StationDataSource : IStationDataSource<TrainsDto>
{
    private string baseUrl = "http://swopenapi.seoul.go.kr/api/subway/sample/json/realtimeStationArrival/0/5/";
    private HttpClient _httpClient;

    public StationDataSource(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Should check if parameter:stationName(Korean) automately converted into base64
    public async Task<Response<TrainsDto>> GetStationInfoAsync(string stationName)
    {
        // Response<T> parameters
        Dictionary<string, string> headers;
        int statusCode;
        TrainsDto? contentBody;
        
        // HTTP GET
        HttpResponseMessage response = await _httpClient.GetAsync($"{baseUrl}{stationName}");
        
        // Header
        headers = response.Headers.ToDictionary(
            header => header.Key,
            header => string.Join(", ", header.Value)
        );
        
        // Status code
        statusCode = (int) response.StatusCode;
        
        // Content
        string stringifiedContentBody = await response.Content.ReadAsStringAsync();

        // Is convertable to DTO?
        try
        {
            contentBody = JsonConvert.DeserializeObject<TrainsDto>(stringifiedContentBody);
        }
        catch
        {
            contentBody = new TrainsDto();
            statusCode = -1;
        }

        return new Response<TrainsDto>(
            statusCode: statusCode,
            header: headers,
            body: contentBody
        );
    }
}