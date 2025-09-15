using CsharpStudy.Network.Interfaces;
using CsharpStudy.Network.Models;

namespace CsharpStudy.Network.Repositories;

public class PokemonRepository : IRepository<Pokemon>
{
    private IDataSource<Pokemon> _dataSource;

    public PokemonRepository(IDataSource<Pokemon> dataSource)
    {
        _dataSource = dataSource;
    }

    public async Task<Pokemon?> GetByNameAsync(string name)
    {
        var response = await _dataSource.GetNameAsync(name);
        return response.Body;
    }
}