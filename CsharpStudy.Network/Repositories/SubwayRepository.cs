using CsharpStudy.Network.DTOs;
using CsharpStudy.Network.Interfaces;
using CsharpStudy.Network.Mappers;
using CsharpStudy.Network.Models;
using Newtonsoft.Json;

namespace CsharpStudy.Network.Repositories;

public enum SubwayApiError
{
    NetworkTimeout,
    NotFound,
    Unknown,
    AuthenticationFailed,
    JsonSerialization,
    BadRequest,
}

public class SubwayRepository(IDataSource<SubwayArrivalDto> dataSource) : IRepository<Result<SubwayArrival, SubwayApiError>>
{
    private IDataSource<SubwayArrivalDto> _dataSource = dataSource;

    public async Task<Result<SubwayArrival, SubwayApiError>> GetByNameAsync(string name)
    {
        try
        {
            var response = await _dataSource.GetNameAsync(name);

            switch (response.StatusCode)
            {
                case 200:
                    return new Result<SubwayArrival, SubwayApiError>.Success(SubwayArrivalMapper.ToModel(response.Body));
                case 400:
                    return new Result<SubwayArrival, SubwayApiError>.Error(SubwayApiError.BadRequest);
                case 404:
                    return new Result<SubwayArrival, SubwayApiError>.Error(SubwayApiError.NotFound);
                case 408:
                    return new Result<SubwayArrival, SubwayApiError>.Error(SubwayApiError.NetworkTimeout);
                default:
                    return new Result<SubwayArrival, SubwayApiError>.Error(SubwayApiError.Unknown);
            }
        }
        catch (JsonSerializationException e)
        {
            return new Result<SubwayArrival, SubwayApiError>.Error(SubwayApiError.JsonSerialization);
        }
        catch (Exception e)
        {
            return new Result<SubwayArrival, SubwayApiError>.Error(SubwayApiError.Unknown);
        }
    }
}