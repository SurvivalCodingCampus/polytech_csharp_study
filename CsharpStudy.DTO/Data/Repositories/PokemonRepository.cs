using CsharpStudy.DTO.Data.Common;
using CsharpStudy.DTO.Data.DataSources;
using CsharpStudy.DTO.Data.Mappers;
using CsharpStudy.DTO.Data.Models;

namespace CsharpStudy.DTO.Data.Repositories;

public class PokemonRepository : IPokemonRepository
{
    private IPokemonDataSource _dataSource;

    public PokemonRepository(IPokemonDataSource dataSource)
    {
        _dataSource = dataSource;
    }
    
    public async Task<Result<Pokemon?, PokemonError>> GetPokemonByNameAsync(string pokemonName)
    {
        try
        {
            Response<PokemonDto> response = await _dataSource.GetPokemonAsync(pokemonName);

            switch (response.StatusCode)
            {
                case 200:
                    return new Result<Pokemon?, PokemonError>.Success(response.Body.ToPokemon());
                case 401:
                    return new Result<Pokemon?, PokemonError>.Error(PokemonError.AuthenticationFailed);
                case 404:
                    return new Result<Pokemon?, PokemonError>.Error(PokemonError.NotFound);
                case -1:
                    return new Result<Pokemon?, PokemonError>.Error(PokemonError.NetworkTimeout);
                default:
                    return new Result<Pokemon?, PokemonError>.Error(PokemonError.Unknown);
            }
        }
        catch (Exception e)
        {
            return new Result<Pokemon?, PokemonError>.Error(PokemonError.Unknown);
        }
    }
}