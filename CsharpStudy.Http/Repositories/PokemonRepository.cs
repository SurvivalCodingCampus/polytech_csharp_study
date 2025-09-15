using CsharpStudy.Http.DataSources;
using CsharpStudy.Http.Models;

namespace CsharpStudy.Http.Repositories;

public class PokemonRepository : IPokemonRepository
{
    private IPokemonApiDataSource _dataSource;

    public async Task<Pokemon?> GetPokemonByNameAsync(string pokemonName)
    {
        var response = await _dataSource.GetPokemonAsync(pokemonName);
        return response.Body;
    }
}