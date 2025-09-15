using CsharpStudy.HttpPokeMon.DataSources;
using CsharpStudy.HttpPokeMon.Mapper;
using CsharpStudy.HttpPokeMon.Models;

namespace CsharpStudy.HttpPokeMon.Repository;

public class PokemonRepository<PokemonDTO>
{
    private IPokemonApiDataSource<PokemonDTO> _apiDataSource;
    
    // 생성자
    public PokemonRepository(IPokemonApiDataSource<PokemonDTO> pokemonRepository)
    {
        _apiDataSource = pokemonRepository;
    }

    public async Task<Pokemon?> GetPokemonByNameAsync(string pokemonName)
    {
        try
        {
            var response = await _apiDataSource.GetPokemonAsync(pokemonName);
            return PokemonMapper.ToPokemon(response.Body);
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}