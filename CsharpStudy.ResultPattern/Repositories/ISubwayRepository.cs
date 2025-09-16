using CsharpStudy.ResultPattern.Common;
using CsharpStudy.ResultPattern.DTOs;

namespace CsharpStudy.ResultPattern.Repositories;

public interface ISubwayRepository
{
    Task<(Result result, List<Arrival>? data)> GetArrivalsAsync(string stationNameKo);
}