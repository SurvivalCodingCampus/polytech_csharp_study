using CshapStudy.SubwayData.DTO;
using CsharpStudy.HttpPokeMon.DTO;

namespace CsharpStudy.HttpPokeMon.DataSources;

public interface IPokemonApiDataSource <T>
{
    // Task<Response<List<T>>> GetAllAsync();
    Task<Response<PokemonDTO?>> GetPokemonAsync(string pokemonName);
}