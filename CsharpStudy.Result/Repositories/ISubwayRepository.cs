using CsharpStudy.Result.DataSources;
using CsharpStudy.Result.Models;

namespace CsharpStudy.Result.Repositories;

public interface ISubwayRepository
{
    Task<Result<List<Subway>, SubwayError>> GetSubwayByNameAsync(string subwayName);
}