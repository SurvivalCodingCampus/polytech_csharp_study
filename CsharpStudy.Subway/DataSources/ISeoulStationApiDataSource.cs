
namespace CsharpStudy.Subway.DataSources;

public interface ISeoulStationApiDataSource
{
    public Task<Response<SeoulStationDto>>GetSeoulStationAsync(string stationName);
}