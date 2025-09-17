using CsharpStudy.HttpStudy.DataSources;
using CsharpStudy.HttpStudy.DTO;

namespace CsharpStudy.HttpStudy.Data;

public interface IPokemonApiDataSource
{
    Task<Response<PokemonDto>> GetPokemonAsync(string pokemonName);
}