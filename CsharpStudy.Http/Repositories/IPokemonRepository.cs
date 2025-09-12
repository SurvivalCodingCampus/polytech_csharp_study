using CsharpStudy.Http.Models;

namespace CsharpStudy.Http.Repositories;

public interface IPokemonRepository
{
    Task<Models.Pokemon> GetPokemonByNameAsync(string pokemonName);
}