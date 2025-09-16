using System.Text.Json;
using CshapStudy.SubwayData.Common;
using CshapStudy.SubwayData.DTO;
using CshapStudy.SubwayData.Model;

namespace CsharpStudy.HttpPokeMon.DataSources;

public class RemoteSubwayDataSource : ISubwayApiDataSource<SubwayDto>
{
    private const string BaseUrl = "http://swopenapi.seoul.go.kr/api/subway/sample/json/realtimeStationArrival/0/5/";
    private static HttpClient _httpClient;

    public RemoteSubwayDataSource(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<Response<SubwayDto?>> GetSubwayAsync(string subwayName)
    {
        var response = await _httpClient.GetAsync($"{BaseUrl}/{subwayName}");
        try
        {
            var jsonString = await response.Content.ReadAsStringAsync();


            if (!response.IsSuccessStatusCode)
            {
                return new Response<SubwayDto?>(
                    statusCode: (int)response.StatusCode,
                    headers: null,
                    body: null // 이 부분 변경!
                );
            }

            var headers = response.Headers.ToDictionary(
                header => header.Key,
                header => string.Join(", ", header.Value)
            );
            
            return new Response<SubwayDto?>(
                statusCode: (int)response.StatusCode,
                headers: headers,
                body: JsonSerializer.Deserialize<SubwayDto>(jsonString) // 이 부분 변경!
            );
        }
        catch (Exception e)
        {
            return new Response<SubwayDto?>(
                statusCode: (int)response.StatusCode,
                headers: null,
                body: null // 이 부분 변경!
            );
        };
    }
}