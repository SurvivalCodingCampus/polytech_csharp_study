using CsharpStudy.HttpPokeMon.Models;

namespace CsharpStudy.HttpPokeMon.Repository;

public interface IPokemonRepository
{
    // Task<List<Pokemon>> GetPostsAsync();
    Task<Pokemon> GetPokemonByNameAsync(string pokemonName);
}