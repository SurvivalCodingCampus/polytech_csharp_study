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
        Response<PokemonDto> response = await _dataSource.GetPokemonAsync(pokemonName);
        
        try
        {
            switch (response.StatusCode)
            {
                case 200:
                    return new Result<Pokemon?, PokemonError>.Success(response.Body.ToPokemon());
                case 401:
                    return new Result<Pokemon?, PokemonError>.Error(PokemonError.AuthenticationFailed);
                case 404:
                    return new Result<Pokemon?, PokemonError>.Error(PokemonError.NotFound);
                case 408:
                    return new Result<Pokemon?, PokemonError>.Error(PokemonError.NetworkTimeout);
                case -1:
                    return new Result<Pokemon?, PokemonError>.Error(PokemonError.JsonSerializationFailed);
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