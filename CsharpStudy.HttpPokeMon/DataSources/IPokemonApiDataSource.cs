namespace CsharpStudy.HttpPokeMon.DataSources;

public interface IPokemonApiDataSource <T>
{
    // Task<Response<List<T>>> GetAllAsync();
    Task<Response<T>> GetPokemonAsync(string pokemonName);
}