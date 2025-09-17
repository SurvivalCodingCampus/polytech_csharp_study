using CsharpStudy.HttpStudy.Common;
using CsharpStudy.HttpStudy.Data;

namespace CsharpStudy.HttpStudy.Repository;

public interface IPokemonRepository
{
    Task<Result<Pokemon, PokemonError>> GetPokemonByNameAsync(string pokemonName);

}