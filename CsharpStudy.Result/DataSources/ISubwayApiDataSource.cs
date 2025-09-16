
using CsharpStudy.Result.DTOs;

namespace CsharpStudy.Result.DataSources;

public interface ISubwayApiDataSource
{
    Task<Response<SubwayDto>> GetSubwayAsync(string subwayName);
}