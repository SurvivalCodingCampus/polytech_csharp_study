using CsharpStudy.HttpPokeMon.Common;
using CsharpStudy.HttpPokeMon.DTO;
using CsharpStudy.HttpPokeMon.Models;

namespace CsharpStudy.HttpPokeMon.Repository;

public interface IPokemonRepository
{
    // Task<List<Pokemon>> GetPostsAsync();
    Task<Result<Models.Pokemon, PokemonError>> GetPokemonByNameAsync(string pokemonName);
}