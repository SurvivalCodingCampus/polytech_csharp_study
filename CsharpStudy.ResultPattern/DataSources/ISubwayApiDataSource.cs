using CsharpStudy.ResultPattern.DTOs;

namespace CsharpStudy.ResultPattern.DataSources;

public interface ISubwayApiDataSource
{
    Task<SubwayResponse?> GetArrivalInfoAsync(string stationNameKo);
}