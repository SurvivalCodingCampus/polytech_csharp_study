using CsharpStudy.Http.DataSources;

namespace CsharpStudy.HttpStudy.Data;

public interface IPokemonApiDataSource<T>
{
    Task<Response<T>> GetPokemonAsync(string pokemonName);
}