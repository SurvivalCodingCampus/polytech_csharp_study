namespace _250912.Data.RepositorySource;

public interface IPokemonRepository
{
    public Task<Pokemon?> GetPokemonByNameAsync(string pokemonName);

}