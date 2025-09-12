using CsharpStudy.Http.Models;

namespace CsharpStudy.Http.DataSources;

public interface IPokemonApiDataSource
{
    Task<Response<Pokemon>> GetPokemonAsync(string pokemonName);
}