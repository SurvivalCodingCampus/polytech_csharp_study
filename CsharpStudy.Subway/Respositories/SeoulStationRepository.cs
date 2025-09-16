using System.Runtime.InteropServices;
using CsharpStudy.Subway.Common;
using CsharpStudy.Subway.DataSources;
using CsharpStudy.Subway.Mappers;
using CsharpStudy.Subway.Models;

namespace CsharpStudy.Subway.Respositories;

public class SeoulStationRepository : ISeoulStationRepository
{
    private ISeoulStationApiDataSource _apiDataSource;

    public SeoulStationRepository(ISeoulStationApiDataSource apiDataSource)
    {
        _apiDataSource = apiDataSource;
    }
    
    public async Task<Result<SeoulStation, SeoulStationError>> GetSeoulStationNameAsync(string stationName)
    {
        if (string.IsNullOrWhiteSpace(stationName))
        {
            return new Result<SeoulStation, SeoulStationError>.Error(SeoulStationError.InvalidInput);
        }

        try
        {
            var response = await _apiDataSource.GetSeoulStationAsync(stationName);

            switch (response.StatusCode)
            {
                case 200:
                    var dto = response.Body;
                    SeoulStation seoulStation = dto.ToModel();
                    
                    return new Result<SeoulStation, SeoulStationError>.Success(seoulStation);
                
                case 404:
                    return new Result<SeoulStation, SeoulStationError>.Error(SeoulStationError.NotFound);
                
                default:
                    return new Result<SeoulStation, SeoulStationError>.Error(SeoulStationError.UnknownError);
            }

        }
        catch (Exception e)
        {
            return new Result<SeoulStation,SeoulStationError>.Error(SeoulStationError.NetworkError);
        }
        
    }
}