using CsharpStudy.HTTP.Models;

namespace CsharpStudy.HTTP.Repositories
{
    public interface IPokemonRepository
    {
        Task<Pokemon> GetPokemonByNameAsync(string pokemonName);
    }
}