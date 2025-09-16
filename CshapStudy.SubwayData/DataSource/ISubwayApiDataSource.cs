using CshapStudy.SubwayData.Common;
using CshapStudy.SubwayData.DTO;
using CshapStudy.SubwayData.Model;

namespace CsharpStudy.HttpPokeMon.DataSources;

public interface ISubwayApiDataSource <T>
{
    // Task<Response<List<T>>> GetAllAsync();
    Task<Response<SubwayDto?>> GetSubwayAsync(string subwayName);
}