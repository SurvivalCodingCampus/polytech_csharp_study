using CsharpStudy.HTTP.DTOs;

namespace CsharpStudy.HTTP.DataSources;

public interface IPokemonApiDataSource
{
    Task<PokemonDto?> GetPokemonAsync(string name);
}