using CsharpStudy.Http.DataSource;
using CsharpStudy.Http.Pokemon.DataSource;

namespace CsharpStudy.Http.Pokemon.DataSource;

public interface IPokemonApiDataSource
{
    Task<Response<Models.Pokemon>> GetPokemonAsync(string pokemonName);
}