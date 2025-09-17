using CsharpStudy.SubwayExam.Core;
using CsharpStudy.SubwayExam.DTOs;
using Newtonsoft.Json;

namespace CsharpStudy.SubwayExam.DataSources;

public class SeoulSubwayInfoDataSource : ISubwayInfoDataSource
{
    private const string BaseUrl = "http://swopenapi.seoul.go.kr/api/subway/sample/json/realtimeStationArrival/0/5";
    private readonly HttpClient _httpClient;

    public SeoulSubwayInfoDataSource(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Result<Response<SubwayInfoDto?>, Response<ErrorMessageDto?>>> GetSubwayInfoAsync(
        string stationName)
    {
        string jsonString = string.Empty;
        try
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/{stationName}");

            jsonString = await response.Content.ReadAsStringAsync();

            var headers = response.Headers.ToDictionary(
                header => header.Key,
                header => string.Join(", ", header.Value)
            );

            var successResponse = new Response<SubwayInfoDto?>(
                statusCode: (int)response.StatusCode,
                headers: headers,
                body: JsonConvert.DeserializeObject<SubwayInfoDto>(jsonString)
            );

            return new Result<Response<SubwayInfoDto?>, Response<ErrorMessageDto?>>.Success(successResponse);
        }
        catch (JsonSerializationException e)
        {
            var errorResponse = new Response<ErrorMessageDto?>(
                statusCode: 404,
                headers: new Dictionary<string, string>(),
                body: JsonConvert.DeserializeObject<ErrorMessageDto>(jsonString)
            );

            return new Result<Response<SubwayInfoDto?>, Response<ErrorMessageDto?>>.Error(errorResponse);
        }
        catch (Exception e)
        {
            return new Result<Response<SubwayInfoDto?>, Response<ErrorMessageDto?>>.Error(null);
        }
    }
}