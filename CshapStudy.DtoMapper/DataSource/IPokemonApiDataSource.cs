using CshapStudy.DtoMapper.DTOs;

namespace CshapStudy.DtoMapper.DataSource;

public interface IPokemonApiDataSource
{
    Task<Response<PokemonDto>> GetPokemonAsync(string pokemonName);
}