using CsharpStudy.Result.Subway.Repositories;
using CsharpStudy.ResultExam.SubwayExam.Models;
using CsharpStudy.ResultExam.SubwayExam.Common;

namespace CsharpStudy.ResultExam.SubwayExam.Repositories;

public interface ISubwayRepository
{
    Task<Result<List<Subway>, SubwayError>> GetSubwayByEndStationNameAsync(string stationName);
}