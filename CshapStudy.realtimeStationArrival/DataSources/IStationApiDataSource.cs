using CshapStudy.realtimeStationArrival.Common;
using CshapStudy.realtimeStationArrival.DTOs;

namespace CshapStudy.realtimeStationArrival.DataSources;

public interface IStationApiDataSource
{
    Task<Response<StationDto>> GetStationAsync(string stationName);
}