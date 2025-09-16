using CsharpStudy.DTO.DTOs;
using CsharpStudy.DTO.Model;

namespace CsharpStudy.DTO.Repositories
{
    public interface IPokemonRepository
    {
      Task<PokemonDto?> GetPokemonAsync(string pokemonName);
    }
}
