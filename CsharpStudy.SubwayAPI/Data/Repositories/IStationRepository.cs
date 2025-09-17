using CsharpStudy.SubwayAPI.Data.Common;
using CsharpStudy.SubwayAPI.Data.Models;

namespace CsharpStudy.SubwayAPI.Data.Repositories;

public interface IStationRepository
{
    Task<Result<List<Train>, StationError>> GetStationInfoByNameAsync(string stationName);
}