namespace CsharpStudy.Http.DataSources;

public interface IPokemonApiDataSource<T>
{
    Task<Response<T>> GetPokemonAsync(string pokemonName);

}