using CsharpStudy.SubwayExam.Core;
using CsharpStudy.SubwayExam.Models;


namespace CsharpStudy.SubwayExam.Repository;

public interface ISubwayRepository
{
    Task<Result<List<SubwayArrivalInfo>, SubwayError>> GetArrivalInfoAsync(string stationName);
}