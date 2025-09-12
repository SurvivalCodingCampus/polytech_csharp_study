using Csharp_study.http.DataSources;
using Csharp_study.http.Model;

namespace Csharp_study.http.Repositories;

public class PockemonPostrepository : IPokemonRepository
{
    private IPokemonApiDataSource<Pokemon> _pokemonApiDataSource;

    public PockemonPostrepository(IPokemonApiDataSource<Pokemon> pokemonApiDataSource)
    {
        _pokemonApiDataSource = pokemonApiDataSource;
    }
    
    public async Task<Pokemon?> GetPokemonByNameAsync(string pokemonName)
    {
        var response = await _pokemonApiDataSource.GetPokemonAsync(pokemonName);
        return response.Body;
    }
}