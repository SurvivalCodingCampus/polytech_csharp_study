using CshapStudy.realtimeStationArrival.DataSources;
using CshapStudy.realtimeStationArrival.Mappers;
using CshapStudy.realtimeStationArrival.Models;
using CshapStudy.realtimeStationArrival.Common;

namespace CshapStudy.realtimeStationArrival.Repositories;

public class StationRepository : IStationRepository
{
    private IStationApiDataSource _dataSource;

    public StationRepository(IStationApiDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public async Task<Result<List<Station>, StationError>> GetStationAsync(string stationName)
    {
        if (string.IsNullOrWhiteSpace(stationName))
        {
            return new Result<List<Station>, StationError>.Error(StationError.InvalidInput);
        }

        try
        {
            var response = await _dataSource.GetStationAsync(stationName);

            switch (response.StatusCode)
            {
                case 200:
                    var dto = response.Body;
                    var station = dto.ToModels();
                    return new Result<List<Station>, StationError>.Success(station);
                case 404:
                    return new Result<List<Station>, StationError>.Error(StationError.NotFound);
                default:
                    return new Result<List<Station>, StationError>.Error(StationError.UnknownError);
            }

        }
        catch (Exception)
        {
            return new Result<List<Station>, StationError>.Error(StationError.NetworkError);
        }
    }
}


