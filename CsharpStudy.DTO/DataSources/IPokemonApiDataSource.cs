using CsharpStudy.DTO.DataSources;
using CsharpStudy.DTO.Model;

namespace CsharpStudy.DTO.DTOs;

public interface IPokemonApiDataSource
{ 
    Task<Response<PokemonDto>> GetPokemonAsync(string pokemonName);
}