using CsharpStudy.StationAPI.Data.Common;

namespace CsharpStudy.StationAPI.Data.DataSources;

public interface IStationDataSource<T>
{
    Task<Response<T>> GetStationInfoAsync(string stationName);
}