using Pokemon.DataSource;

namespace Pokemon.Repositories;

public class PokemonRepository : IPokemonRepository
{
    private readonly IPokemonApiDataSource _dataSource;

    public PokemonRepository(IPokemonApiDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public async Task<Pokemon?> GetPokemonByNameAsync(string pokemonName)
    {
        var response = await _dataSource.GetPokemonAsync(pokemonName);
        return response.Body;
    }
}