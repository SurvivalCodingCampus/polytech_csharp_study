using CsharpStudy.DTO.Data.DataSources;
using CsharpStudy.DTO.Data.Models;

namespace CsharpStudy.DTO.Data.Repositories;

public interface IPokemonRepository
{
    Task<Pokemon?> GetPokemonByNameAsync(string pokemonName);
}