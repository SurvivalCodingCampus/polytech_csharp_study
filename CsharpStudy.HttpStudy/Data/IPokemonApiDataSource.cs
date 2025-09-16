using CsharpStudy.Http.DataSources;
using CsharpStudy.HttpStudy.DTO;

namespace CsharpStudy.HttpStudy.Data;

public interface IPokemonApiDataSource<T>
{
    Task<Response<PokemonDto>> GetPokemonAsync(string pokemonName);
}