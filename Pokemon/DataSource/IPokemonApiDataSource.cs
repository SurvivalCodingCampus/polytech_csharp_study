namespace Pokemon.DataSource;

public interface IPokemonApiDataSource
{
    Task<Response<Pokemon>> GetPokemonAsync(string pokemonName);
}