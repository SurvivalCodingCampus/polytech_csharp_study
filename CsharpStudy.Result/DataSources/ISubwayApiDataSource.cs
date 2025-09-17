using CsharpStudy.Result.Dtos;

namespace CsharpStudy.Result.DataSources;

public interface ISubwayApiDataSource
{
    Task<Response<ApiResponseDto>> GetSubwayAsync(string  stationName);
}