using CsharpStudy.SubwayAPI.Data.Common;

namespace CsharpStudy.SubwayAPI.Data.DataSources;

public interface IStationDataSource<T>
{
    Task<Response<T>> GetStationInfoAsync(string stationName);
}