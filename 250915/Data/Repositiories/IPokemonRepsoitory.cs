using _250915.Data.Models;

namespace _250915.Data.Repositiories;

public interface IPokemonRepsoitory
{
    public Task<PokemonDto?> GetPokemonByNameAsync(string pokemonName);
}