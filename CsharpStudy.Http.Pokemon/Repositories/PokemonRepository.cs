using CsharpStudy.Http.DataSource;
using CsharpStudy.Http.Pokemon.DataSource;

namespace CsharpStudy.Http.Pokemon.Repositories;

public class PokemonRepository : IPokemonRepository
{
    private IPokemonApiDataSource _dataSource;

    public PokemonRepository(IPokemonApiDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public async Task<Models.Pokemon> GetPokemonByNameAsync(string pokemonName)
    {
        DataSource.Response<Models.Pokemon> response = await _dataSource.GetPokemonAsync(pokemonName);
        return response.Body;
    }
}