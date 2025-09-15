using CsharpStudy.HttpPokeMon.DataSources;
using CsharpStudy.HttpPokeMon.Models;

namespace CsharpStudy.HttpPokeMon.Repository;

public class PokemonRepository<Pokemon>
{
    private IPokemonApiDataSource<Pokemon> _apiDataSource;

    // 생성자
    public PokemonRepository(IPokemonApiDataSource<Pokemon> pokemonRepository)
    {
        _apiDataSource = pokemonRepository;
    }

    public async Task<Pokemon?> GetPokemonByNameAsync(string pokemonName)
    {
        var response = await _apiDataSource.GetPokemonAsync(pokemonName);
        return response.Body ;
    }
}