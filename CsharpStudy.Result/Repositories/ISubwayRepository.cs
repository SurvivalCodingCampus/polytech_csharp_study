using CsharpStudy.Result.Common;

namespace CsharpStudy.Result.Repositories;

public interface ISubwayRepository
{
    Task<Result<Models.Subway, SubwayError>> GetSubwayByNameAsync(string subwayName);
}