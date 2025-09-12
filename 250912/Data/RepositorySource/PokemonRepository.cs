using _250912.Data.DataSource;
using Newtonsoft.Json;

namespace _250912.Data.RepositorySource;

public class PokemonRepository :IPokemonRepository
{
    private IPokemonApiDataSource<Pokemon> _dataSource;

    public PokemonRepository(IPokemonApiDataSource<Pokemon> dataSource)
    {
        _dataSource = dataSource;
    }
    

    public async Task<Pokemon?> GetPokemonByNameAsync(string pokemonName)
    {
        var response = await _dataSource.GetPokemonAsync(pokemonName);
        return response.Body;
    }
    
}
