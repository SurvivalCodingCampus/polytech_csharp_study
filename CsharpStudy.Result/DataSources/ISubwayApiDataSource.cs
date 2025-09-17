
using CsharpStudy.Result.DTOs;

namespace CsharpStudy.Result.DataSources;

public interface ISubwayApiDataSource<T>
{
    Task<Response<SubwayDto>> GetSubwayAsync(string subwayName);
}