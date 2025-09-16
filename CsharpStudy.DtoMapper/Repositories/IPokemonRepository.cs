using CsharpStudy.DtoMapper.DataSources;

namespace CsharpStudy.DtoMapper.Repositories;

public interface IPokemonRepository
{
    Task<Result<Models.Pokemon, PokemonError>> GetPokemonByNameAsync(string pokemonName);
    
}