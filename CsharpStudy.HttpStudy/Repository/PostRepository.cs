using CsharpStudy.HttpStudy.Data;

namespace CsharpStudy.HttpStudy.Repository;

public class PostRepository : IPokemonRepository
{
    private IPokemonApiDataSource<Pokemon> _dataSource;
    
    public PostRepository(IPokemonApiDataSource<Pokemon> dataSource)
    {
        _dataSource = dataSource;
    }

    public async Task<Pokemon?> GetPokemonByNameAsync(string pokemonName)
    {
        var response = await _dataSource.GetPokemonAsync(pokemonName);
        return response.Body;
    }
}  