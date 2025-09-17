using CsharpStudy.HttpPokeMon.Common;
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

    public async Task<Result<Models.Pokemon, PokemonError>> GetPokemonByNameAsync(string pokemonName)
    {
        
        try
        {
            //Responese<PokemonDTO> response = await _apiDataSource.GetPokemonAsync(pokemonName);
            var response = await _apiDataSource.GetPokemonAsync(pokemonName);
            switch (response.StatusCode)
            {
                case 200:
                    return new Result<Models.Pokemon, PokemonError>.Success(PokemonMapper.ToPokemon(response.Body));
                case 404:
                    return new Result<Models.Pokemon, PokemonError>.Error(PokemonError.NotFound);
                case -1:
                    return new Result<Models.Pokemon, PokemonError>.Error(PokemonError.NetworkTimeout);
                default:
                    return new Result<Models.Pokemon, PokemonError>.Error(PokemonError.Unknown);
            }
        }
        catch (Exception ex)
        {
            return new Result<Models.Pokemon, PokemonError>.Error(PokemonError.Unknown);
        }
    }
}