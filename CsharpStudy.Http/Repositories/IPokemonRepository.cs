using CsharpStudy.Http.Models;

namespace CsharpStudy.Http.Repositories;

public interface IPokemonRepository
{
    Task<Pokemon?> GetPokemonByNameAsync(string pokemonName);
}