using System.Net.Http;
using System.Text.Json;
using CsharpStudy.ResultPattern.DTOs;

namespace CsharpStudy.ResultPattern.DataSources;

public sealed class RemoteSubwayDataSource(HttpClient http) : ISubwayApiDataSource
{
    public async Task<SubwayResponse?> GetArrivalInfoAsync(string stationNameKo)
    {
        var encoded = Uri.EscapeDataString(stationNameKo);
        var url = $"http://swopenapi.seoul.go.kr/api/subway/sample/json/realtimeStationArrival/0/5/{encoded}";
        
        var json = await http.GetStringAsync(url);
        return JsonSerializer.Deserialize<SubwayResponse>(json);
    }
}