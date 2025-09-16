using CsharpStudy.HttpStudy.Data;
using CsharpStudy.HttpStudy.DTO;
using CsharpStudy.HttpStudy.Mapper;

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
        try
        {
            var response = await _dataSource.GetPokemonAsync(pokemonName); // 이놈마를 돌리면 DTO로 날라옴
            var dto = response.Body;
            return Manpper.ToModel(dto);
        }
        catch (Exception e)
        {
            return null;
        }
    }
}

