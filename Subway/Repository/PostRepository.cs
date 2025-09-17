using Subway.Data;
using Subway.Models;

namespace Subway.Repository;

public class PostRepository : ISubwayRepository
{
    private ISubwayApiDataSource _dataSource;

    public PostRepository(ISubwayApiDataSource dataSource)
    {
        _dataSource = dataSource;
    }
    
    public async Task<BarvlDt> GetSubwayByNameAsync(string subwayName)
    {
        var response = await _dataSource.GetPokemonAsync(subwayName);

        return response;
    }
}