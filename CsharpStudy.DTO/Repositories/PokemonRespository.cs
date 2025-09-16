using CsharpStudy.DTO.DTOs;

namespace CsharpStudy.DTO.Repositories;

public class PokemonRespository: IPokemonRepository
{
    private IPokemonApiDataSource<PokemonDto> _dataSource;

    public PokemonRespository(IPokemonApiDataSource<PokemonDto> dataSource)
    {
        _dataSource = dataSource;
    }
    

    public async Task<PokemonDto?> GetPokemonAsync(string pokemonName)
    {
        var response = await _dataSource.GetPokemonAsync(pokemonName);
        return response.Body;
    }
}