using CsharpStudy.Result.Common;
using CsharpStudy.Result.DataSources;
using CsharpStudy.Result.DTOs;
using CsharpStudy.Result.Mappers;
using CsharpStudy.Result.Models;

namespace CsharpStudy.Result.Repositories;

public class SubwayRepository<SubwayDto> : ISubwayRepository
{
    private ISubwayApiDataSource<SubwayDto> _dataSource;

    public SubwayRepository(ISubwayApiDataSource<SubwayDto> dataSource)
    {
        _dataSource = dataSource;
    }


    public async Task<Result<Models.Subway, SubwayError>> GetSubwayByNameAsync(string subwayName)
    {
        if (string.IsNullOrWhiteSpace(subwayName))
        {
            return new Result<Models.Subway, SubwayError>.Error(SubwayError.InvalidInput);
        }
        try
        {
            var response = await _dataSource.GetSubwayAsync(subwayName);

            switch (response.StatusCode)
            {
                case 200:
                    var dto = response.Body;
                    Subway subway = dto.ToSubwayModel();
                    return new Result<Subway, SubwayError>.Success(subway);
                case 404:
                    return new Result<Subway, SubwayError>.Error(SubwayError.NotFound);
                default:
                    return new Result<Subway, SubwayError>.Error(SubwayError.UnknownError);
            }
        }
        catch (Exception e)
        {
            return new Result<Subway, SubwayError>.Error(SubwayError.NetworkError);
        }
    }
}