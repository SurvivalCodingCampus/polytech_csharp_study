using CsharpStudy.HttpStudy.Data;

namespace CsharpStudy.HttpStudy.Repository;

public interface IPokemonRepository
{
    Task<Pokemon?> GetPokemonByNameAsync(string pokemonName);
}