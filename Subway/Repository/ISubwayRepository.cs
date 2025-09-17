using Subway.Models;

namespace Subway.Repository;

public interface ISubwayRepository
{
    Task<BarvlDt> GetSubwayByNameAsync(string subwayName);
}