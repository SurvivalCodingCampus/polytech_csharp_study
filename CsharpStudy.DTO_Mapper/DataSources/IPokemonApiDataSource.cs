using CsharpStudy.DTO_Mapper.DTO;
using CsharpStudy.DTO_Mapper.Models;

namespace CsharpStudy.DTO_Mapper.DataSources;

public interface IPokemonApiDataSource
{
    Task<Response<PokemonDto>> GetPokemonAsync(string pokemonName);
}