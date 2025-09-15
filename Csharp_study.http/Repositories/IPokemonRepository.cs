using Csharp_study.http.Model;

namespace Csharp_study.http.Repositories;

public interface IPokemonRepository
{
    Task<Pokemon?> GetPokemonByNameAsync(string pokemonName);
}