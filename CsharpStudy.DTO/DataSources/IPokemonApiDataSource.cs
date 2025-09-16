using CsharpStudy.DTO.DataSources;
using CsharpStudy.DTO.Model;

namespace CsharpStudy.DTO.DTOs;

public interface IPokemonApiDataSource<T>
{
   public Task<Response> GetPokemonAsync(string pokemonName);
}