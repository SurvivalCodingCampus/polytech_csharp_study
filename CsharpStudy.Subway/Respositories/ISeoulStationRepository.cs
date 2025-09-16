using CsharpStudy.Subway.Common;

namespace CsharpStudy.Subway.Respositories;

public interface ISeoulStationRepository
{
    Task<Result<Models.SeoulStation,SeoulStationError>> GetSeoulStationNameAsync(string stationName);
}