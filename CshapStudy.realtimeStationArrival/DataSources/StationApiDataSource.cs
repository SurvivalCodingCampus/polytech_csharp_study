using CshapStudy.realtimeStationArrival.Common;
using CshapStudy.realtimeStationArrival.DTOs;
using CshapStudy.realtimeStationArrival.Models;
using Newtonsoft.Json;

namespace CshapStudy.realtimeStationArrival.DataSources;

public class StationApiDataSource : IStationApiDataSource
{
    private const string BaseUrl ="http://swopenapi.seoul.go.kr/api/subway/sample/json/realtimeStationArrival/0/5/";
    private HttpClient _httpClient;

    public StationApiDataSource(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Response<StationDto>> GetStationAsync(string stationName)
    {
        var encodedStationName = System.Net.WebUtility.UrlEncode(stationName); // 이 줄을 추가합니다.
        var response = await _httpClient.GetAsync($"{BaseUrl}{encodedStationName}"); // encodedStationName을 사용합니다.
        var jsonString = await response.Content.ReadAsStringAsync();
        var headers = response.Headers.ToDictionary(
            header => header.Key,
            header => string.Join(",", header.Value)
        );

        return new Response<StationDto>(
            statusCode: (int)response.StatusCode,
            headers: headers,
            body: JsonConvert.DeserializeObject<StationDto>(jsonString)!
        );
    }
}

