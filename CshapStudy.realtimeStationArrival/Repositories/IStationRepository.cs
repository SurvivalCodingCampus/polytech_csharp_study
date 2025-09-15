using CshapStudy.realtimeStationArrival.Common;
using CshapStudy.realtimeStationArrival.Models;

namespace CshapStudy.realtimeStationArrival.Repositories;

public interface IStationRepository
{
    Task<Result<List<Station>,StationError>> GetStationAsync(String stationName);
    
}