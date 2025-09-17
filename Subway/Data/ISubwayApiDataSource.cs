using Subway.Models;

namespace Subway.Data;

public interface ISubwayApiDataSource
{
    Task<BarvlDt> GetPokemonAsync(string subwayName);
}