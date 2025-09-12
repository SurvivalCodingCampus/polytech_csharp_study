using CsharpStudy.Http.Models;

namespace CsharpStudy.Http.DataSources;

public interface IPokemonApiDataSource
{
    Task<P_Response<Pokemon>> GetPokemonAsync(string pokemonName);
}