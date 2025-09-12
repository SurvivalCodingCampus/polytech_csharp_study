using CsharpStudy.Http.DataSources;
using CsharpStudy.Http.Models;

namespace CsharpStudy.Http.Repositories;

public class PostPokemonRepository: IPokemonRepository
{
    private IPokemonApiDataSource<Pokemon> _dataSource;
    
    public async Task<Pokemon?> GetPokemonByNameAsync(string pokemonName)
    {
        var response = await _dataSource.GetPokemonAsync(pokemonName);
        return response.Body;
    }
}