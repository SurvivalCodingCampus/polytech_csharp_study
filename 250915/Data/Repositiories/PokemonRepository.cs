using _250915.Data.DataSources;
using _250915.Data.Models;

namespace _250915.Data.Repositiories;

public class PokemonRepository : IPokemonRepsoitory
{
    private IPokemonApiDataSource<Pokemon> _DataSource;

    public PokemonRepository(IPokemonApiDataSource<Pokemon> dataSource)
    {
        _DataSource = dataSource;
    }

    public async Task<PokemonDto?> GetPokemonByNameAsync(string pokemonName)
    {
        var response = await _DataSource.GetPokemonAsync(pokemonName);
        return response.Body;
    }


}