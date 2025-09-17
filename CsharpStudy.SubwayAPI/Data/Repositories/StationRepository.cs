using CsharpStudy.SubwayAPI.Data.Common;
using CsharpStudy.SubwayAPI.Data.DataSources;
using CsharpStudy.SubwayAPI.Data.Mappers;
using CsharpStudy.SubwayAPI.Data.Models;

namespace CsharpStudy.SubwayAPI.Data.Repositories;

public class StationRepository : IStationRepository
{
    private IStationDataSource<TrainsDto> _dataSource;

    public StationRepository(IStationDataSource<TrainsDto> dataSource)
    {
        _dataSource = dataSource;
    }
    
    public async Task<Result<List<Train>, StationError>> GetStationInfoByNameAsync(string stationName)
    {
        Response<TrainsDto> response = await _dataSource.GetStationInfoAsync(stationName);

        try
        {
            switch (response.StatusCode)
            {
                case 200:
                    return new Result<List<Train>, StationError>.Success(response.Body.ToStation());
                case 404:
                    return new Result<List<Train>, StationError>.Error(StationError.PageNotFound);
                case 408:
                    return new Result<List<Train>, StationError>.Error(StationError.TimedOut);
                case -1:
                    return new Result<List<Train>, StationError>.Error(StationError.JsonSerializeFailed);
                default:
                    Console.WriteLine($"Code returned: {response.StatusCode}");
                    return new Result<List<Train>, StationError>.Error(StationError.Unknown);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Code returned: {response.StatusCode}");
            return new Result<List<Train>, StationError>.Error(StationError.Unknown);
        }
    }
}