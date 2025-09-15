using CsharpStudy.DTO_Mapper.Models;

namespace CsharpStudy.DTO_Mapper.Repositories;

public interface IPokemonRepository
{
    Task<Pokemon?> GetPokemonByNameAsync(string pokemonName);
}