using CsharpStudy.Result.Subway.Repositories;
using CsharpStudy.ResultExam.SubwayExam.Models;
using CsharpStudy.ResultExam.SubwayExam.Common;
using CsharpStudy.ResultExam.SubwayExam.DataSource;
using CsharpStudy.ResultExam.SubwayExam.Mappers;

namespace CsharpStudy.ResultExam.SubwayExam.Repositories;

public class SubwayRepository : ISubwayRepository
{
    private ISubwayApiDataSource _dataSource;

    public SubwayRepository(ISubwayApiDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public async Task<Result<List<Subway>, SubwayError>> GetSubwayByEndStationNameAsync(string stationName)
    {
        if (string.IsNullOrWhiteSpace(stationName))
        {
            return new Result<List<Subway>, SubwayError>.Error(SubwayError.InvalidInput);
        }

        try
        {
            var response = await _dataSource.GetSubwayArrivalAsync(stationName);

            switch (response.StatusCode)
            {
                case 200:
                    var dto = response.Body;
                    List<Subway> subways = dto.ToModel();
                    return new Result<List<Subway>, SubwayError>.Success(subways);
                case 404:
                    return new Result<List<Subway>, SubwayError>.Error(SubwayError.NotFound);
                default:
                    return new Result<List<Subway>, SubwayError>.Error(SubwayError.UnKnownError);
            }
        }
        catch (Exception e)
        {
            return new Result<List<Subway>, SubwayError>.Error(SubwayError.NetworkError);
        }
    }


//throw new NotImplementedException();
}