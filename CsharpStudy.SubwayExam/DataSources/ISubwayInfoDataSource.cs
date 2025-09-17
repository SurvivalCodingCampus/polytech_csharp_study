using CsharpStudy.SubwayExam.Core;
using CsharpStudy.SubwayExam.DTOs;

namespace CsharpStudy.SubwayExam.DataSources;

public interface ISubwayInfoDataSource
{
    Task<Result<Response<SubwayInfoDto?>, Response<ErrorMessageDto?>>> GetSubwayInfoAsync(string stationName);
}