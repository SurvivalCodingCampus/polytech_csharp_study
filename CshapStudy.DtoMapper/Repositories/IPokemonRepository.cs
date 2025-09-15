using CshapStudy.DtoMapper.Common;

namespace CshapStudy.DtoMapper.Repositories;

public interface IPokemonRepository
{
    Task<Result<Models.Pokemon, PoKemonError>> GetPokemonByNameAsync(string pokemonName);
}