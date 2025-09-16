using CsharpStudy.Result.Models;
using CsharpStudy.Result.DataSources;
using CsharpStudy.Result.Dtos;
using CsharpStudy.Result.Mappers;
using Newtonsoft.Json;


namespace CsharpStudy.Result.Repositories;

public class SubwayRepository: ISubwayRepository
{
    private ISubwayApiDataSource _dataSource;

    public SubwayRepository(ISubwayApiDataSource dataSource)
    {
        _dataSource = dataSource;
    }
    
    
    public async Task<Result<Subway, SubwayError>> GetSubwayByNameAsync(string stationName)
    {
        try // 에러타입 받아주기
        {
            Response<SubwayDto> response = await _dataSource.GetSubwayAsync(stationName);

            switch (response.StatusCode)
            {
                case 200:
                    return new Result<Subway, SubwayError>.Success(response.Body.ToModel());
                case 404:
                    return new Result<Subway, SubwayError>.Error(SubwayError.NotFound);
                default:
                    return new Result<Subway, SubwayError>.Error(SubwayError.UnknownError);

            }
        }
        catch (TimeoutException e)
        {
            return new Result<Subway, SubwayError>.Error(SubwayError.Timeout);
        }
        
        catch (JsonSerializationException e)
        {
            return new Result<Subway, SubwayError>.Error(SubwayError.Timeout);
        }
        
        catch (Exception e)
        {
            return new Result<Subway, SubwayError>.Error(SubwayError.NetworkError);
        }
    }
    
}