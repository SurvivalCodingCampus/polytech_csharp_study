
using CshapStudy.SubwayData.Common;
using CshapStudy.SubwayData.Model;
using CshapStudy.SubwayData.Repository;

namespace CsharpStudy.HttpPokeMon.Repository;

public interface ISubwayRepository
{
    Task<Result<Subway, SubwayError>> GetSubwayByNameAsync(string subwayName);
}