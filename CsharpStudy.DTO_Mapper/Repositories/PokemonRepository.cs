using System.Data;
using CsharpStudy.DTO_Mapper.DataSources;
using CsharpStudy.DTO_Mapper.Mappers;
using CsharpStudy.DTO_Mapper.Models;

namespace CsharpStudy.DTO_Mapper.Repositories;

public class PokemonRepository : IPokemonRepository
{
    private IPokemonApiDataSource _dataSource;

    public PokemonRepository(IPokemonApiDataSource dataSource)
    {
        _dataSource = dataSource;
    }
    
    public async Task<Pokemon?> GetPokemonByNameAsync(string pokemonName)
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