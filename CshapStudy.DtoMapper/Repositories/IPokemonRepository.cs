namespace CshapStudy.DtoMapper.Repositories;

public interface IPokemonRepository
{
    Task<DtoMapper.Models.Pokemon?> GetPokemonByNameAsync(string pokemonName);
}