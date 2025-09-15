using CsharpStudy.Http.DataSources;
using CsharpStudy.Http.Models;

namespace CsharpStudy.Http.Repositories;

public class PokemonRepository : IPokemonRepository
{
    private IPokemonApiDataSource _pokemonApi;

    public PokemonRepository(IPokemonApiDataSource pokemonApi)
    {
        _pokemonApi = pokemonApi;
    }

    public async Task<Pokemon> GetPokemonByNameAsync(string pokemonName)
    {
        if (string.IsNullOrWhiteSpace(pokemonName))
            throw new ArgumentException("pokemonName is required.", nameof(pokemonName));

        var response = await _pokemonApi.GetPokemonAsync(pokemonName);
        if (response.StatusCode != 200 || response.Body is null)
            throw new KeyNotFoundException($"Pokemon '{pokemonName}' not found. (StatusCode: {response.StatusCode})");
        return response.Body;
    }
}
