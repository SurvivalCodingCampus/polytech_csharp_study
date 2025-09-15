using CsharpStudy.DtoMapper.DataSources;
using CsharpStudy.DtoMapper.Mappers;

namespace CsharpStudy.DtoMapper.Repositories;

public class PokemonRepository : IPokemonRepository
{
    private IPokemonApiDataSource _dataSource;

    public PokemonRepository(IPokemonApiDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public async Task<Models.Pokemon?> GetPokemonByNameAsync(string pokemonName)
    {
        try
        {
            var response = await _dataSource.GetPokemonAsync(pokemonName);
            var dto = response.Body;
            return dto.ToModel();
        }
        catch (Exception e)
        {
            return null;
        }
    }
}