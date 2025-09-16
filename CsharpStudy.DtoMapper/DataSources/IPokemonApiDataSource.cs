using CsharpStudy.DtoMapper.DTOs;

namespace CsharpStudy.DtoMapper.DataSources;

public interface IPokemonApiDataSource
{
    Task<Response<PokemonDto>> GetPokemonAsync(string pokemonName);
}