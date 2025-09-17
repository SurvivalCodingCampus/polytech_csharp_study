namespace CsharpStudy.Pokemon.Repositories;

public interface IPokemonRepository
{
    Task<Models.Pokemon?> GetPokemonByNameAsync(string pokemonName);
}