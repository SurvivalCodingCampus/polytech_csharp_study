using CsharpStudy.DTO.Data.DataSources;
using CsharpStudy.DTO.Data.Mappers;
using CsharpStudy.DTO.Data.Models;

namespace CsharpStudy.DTO.Data.Repositories;

public class PokemonRepository : IPokemonRepository
{
    private IPokemonDataSource _dataSource;

    public PokemonRepository(IPokemonDataSource dataSource)
    {
        _dataSource = dataSource;
    }
    
    public async Task<Pokemon?> GetPokemonByNameAsync(string pokemonName)
    {
        try
        {
            Response<PokemonDto> response = await _dataSource.GetPokemonAsync(pokemonName);
            PokemonDto dto = response.Body;
            return dto.ToPokemon();
        }
        catch (Exception e)
        {
            return null;
        }
    }
}