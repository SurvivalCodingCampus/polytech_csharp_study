namespace CsharpStudy.Pokemon.DataSources;

public interface IPokemonApiDataSource
{
    Task<Response<Models.Pokemon>> GetPokemonAsync(string pokemonName);
}