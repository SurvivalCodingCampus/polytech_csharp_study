using CsharpStudy.Http.Models;

namespace CsharpStudy.Http.DataSources;

public interface IPokemonApiDataSource<T>
{
    Task<Response<Pokemon>> GetPokemonAsync(string pokemonName);
}