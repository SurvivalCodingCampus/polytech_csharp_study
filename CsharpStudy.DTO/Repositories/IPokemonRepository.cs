using CsharpStudy.DTO.Common;
using CsharpStudy.DTO.DTOs;
using CsharpStudy.DTO.Model;

namespace CsharpStudy.DTO.Repositories
{
    public interface IPokemonRepository
    {
     Task<Result<Pokemon, PokemonError>> GetPokemonByNameAsync(string pokemonName);
    }
}
