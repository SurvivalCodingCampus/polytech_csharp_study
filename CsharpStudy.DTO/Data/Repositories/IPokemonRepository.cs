using CsharpStudy.DTO.Data.Common;
using CsharpStudy.DTO.Data.Models;

namespace CsharpStudy.DTO.Data.Repositories;

public interface IPokemonRepository
{
    Task<Result<Pokemon?, PokemonError>> GetPokemonByNameAsync(string pokemonName);
}