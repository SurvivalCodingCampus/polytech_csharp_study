using System.Net;
using CsharpStudy.Network.DTOs;
using CsharpStudy.Network.Interfaces;
using Newtonsoft.Json;

namespace CsharpStudy.Network.Datasources;

public class SubwayApiDatasource : IDataSource<SubwayArrivalDto>
{
    private readonly HttpClient _httpClient = new();
    private const string BaseUrl = "http://swopenapi.seoul.go.kr";

    public SubwayApiDatasource()
    {
        _httpClient.BaseAddress = new Uri(BaseUrl);
    }

    public async Task<Response<SubwayArrivalDto>> GetNameAsync(string name)
    {
        var request =
            new HttpRequestMessage(HttpMethod.Get, $"/api/subway/sample/json/realtimeStationArrival/0/5/{name}");

        var response = await _httpClient.SendAsync(request);
        var jsonString = await response.Content.ReadAsStringAsync();

        var headers =
            response.Headers.ToDictionary(
                header => header.Key,
                header => string.Join(", ", header.Value)
            );

        return TryDeserializeJson(jsonString, response, headers);
    }

    private static Response<SubwayArrivalDto> TryDeserializeJson(string jsonString, HttpResponseMessage response,
        Dictionary<string, string> headers)
    {
        try
        {
            var arrivalDto = JsonConvert.DeserializeObject<SubwayArrivalDto>(jsonString) ?? new SubwayArrivalDto();

            if (arrivalDto.ErrorMessage != null)
                return new Response<SubwayArrivalDto>((int)response.StatusCode, headers, arrivalDto);

            Dictionary<string, string> fail =
                JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString) ??
                new Dictionary<string, string>();
            switch (int.Parse(fail["status"]))
            {
                case 500:
                    return new Response<SubwayArrivalDto>((int)HttpStatusCode.NotFound, headers, arrivalDto);
                case 600: case 601:
                    return new Response<SubwayArrivalDto>((int)HttpStatusCode.ServiceUnavailable, headers, arrivalDto);
            }

            return new Response<SubwayArrivalDto>((int)response.StatusCode, headers, arrivalDto);
        }
        catch (JsonSerializationException e)
        {
            if ((int)response.StatusCode != 200)
                return new Response<SubwayArrivalDto>((int)response.StatusCode, headers, new SubwayArrivalDto());
            throw;
        }
        catch (Exception e)
        {
            return new Response<SubwayArrivalDto>((int)response.StatusCode, headers, new SubwayArrivalDto());
        }
    }
}