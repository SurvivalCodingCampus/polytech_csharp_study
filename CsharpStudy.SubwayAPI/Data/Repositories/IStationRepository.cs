using CsharpStudy.StationAPI.Data.Common;

namespace CsharpStudy.SubwayAPI.Data.Repositories;

public interface IStationRepository
{
    Task<Result<StationDto?, StationError>> GetStationInfoByNameAsync(string stationName);
}