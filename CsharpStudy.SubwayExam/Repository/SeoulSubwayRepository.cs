using CsharpStudy.SubwayExam.Core;
using CsharpStudy.SubwayExam.DataSources;
using CsharpStudy.SubwayExam.DTOs;
using CsharpStudy.SubwayExam.Mapper;
using CsharpStudy.SubwayExam.Models;

namespace CsharpStudy.SubwayExam.Repository;

public class SeoulSubwayRepository : ISubwayRepository
{
    private readonly ISubwayInfoDataSource _dataSource;

    public SeoulSubwayRepository(ISubwayInfoDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public async Task<Result<List<SubwayArrivalInfo>, SubwayError>> GetArrivalInfoAsync(string stationName)
    {
        if (string.IsNullOrWhiteSpace(stationName))
        {
            return new Result<List<SubwayArrivalInfo>, SubwayError>.Error(SubwayError.InvalidInput);
        }

        try
        {
            var result = await _dataSource.GetSubwayInfoAsync(stationName);
            switch (result)
            {
                case Result<Response<SubwayInfoDto?>, Response<ErrorMessageDto>>.Success successResult:
                    return SuccessArrivalInfo(successResult);
                case Result<Response<SubwayInfoDto?>, Response<ErrorMessageDto>>.Error errorResult:
                    return new Result<List<SubwayArrivalInfo>, SubwayError>.Error(SubwayError.NotFound);
            }
        }
        catch (Exception e)
        {
            return new Result<List<SubwayArrivalInfo>, SubwayError>.Error(SubwayError.NetworkError);
        }

        return new Result<List<SubwayArrivalInfo>, SubwayError>.Error(SubwayError.UnknownError);
    }

    private Result<List<SubwayArrivalInfo>, SubwayError> SuccessArrivalInfo(
        Result<Response<SubwayInfoDto?>,
            Response<ErrorMessageDto>>.Success successResult
    )
    {
        var response = successResult.data;

        switch (response.StatusCode)
        {
            case 200:
                SubwayInfoDto? subwayInfoDto = response.Body;
                if (subwayInfoDto == null)
                {
                    return new Result<List<SubwayArrivalInfo>, SubwayError>.Error(SubwayError.NotFound);
                }

                List<SubwayArrivalInfo> subwayArrivalInfos = subwayInfoDto.realtimeArrivalList
                    ?.Select(dto => dto.ToModel())
                    .ToList() ?? [];
                return new Result<List<SubwayArrivalInfo>, SubwayError>.Success(subwayArrivalInfos);
            case 404:
                return new Result<List<SubwayArrivalInfo>, SubwayError>.Error(SubwayError.NotFound);
            default:
                return new Result<List<SubwayArrivalInfo>, SubwayError>.Error(SubwayError.UnknownError);
        }
    }
}