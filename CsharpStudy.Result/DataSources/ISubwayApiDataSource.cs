using CsharpStudy.Result.Dtos;

namespace CsharpStudy.Result.DataSources;

public interface ISubwayApiDataSource
{
    Task<Response<SubwayDto>> GetSubwayAsync(string  stationName);
}