using CsharpStudy.DTO.Common;
using CsharpStudy.DTO.DTOs;
using CsharpStudy.DTO.Mapper;
using CsharpStudy.DTO.Model;

namespace CsharpStudy.DTO.Repositories;

public class PokemonRespository: IPokemonRepository
{
    private IPokemonApiDataSource _dataSource;

    public PokemonRespository(IPokemonApiDataSource dataSource)
    {
        _dataSource =  dataSource;
    }
    

    public async Task<Result<Pokemon, PokemonError>> GetPokemonByNameAsync(string pokemonName)
    {
        if (string.IsNullOrWhiteSpace(pokemonName))
        {
            return new Result<Pokemon, PokemonError>.Error(PokemonError.InvalidInput);
        }

        try
        {
            var response = await _dataSource.GetPokemonAsync(pokemonName);

            switch (response.StatusCode)
            {
                case 200:
                    var dto = response.Body;
                    Pokemon pokemon = dto.ToModel();
                    return new Result<Pokemon, PokemonError>.Success(pokemon);
                case 404:
                    return new Result<Pokemon, PokemonError>.Error(PokemonError.NotFound);
                default:
                    return new Result<Pokemon, PokemonError>.Error(PokemonError.UnkonwnError);
            }

        }
        catch (Exception e)
        {
            return new Result<Pokemon, PokemonError>.Error(PokemonError.NetworkError);
        }
    }
}