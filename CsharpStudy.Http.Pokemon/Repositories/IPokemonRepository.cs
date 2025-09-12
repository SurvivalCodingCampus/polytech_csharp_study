using CsharpStudy.Http.DataSource;

namespace CsharpStudy.Http.Pokemon.Repositories;

public interface IPokemonRepository
{
    Task<Models.Pokemon> GetPokemonByNameAsync(string pokemonName);
}