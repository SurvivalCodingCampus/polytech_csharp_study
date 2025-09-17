using CsharpStudy.DtoMapper.Common;
using CsharpStudy.DtoMapper.DataSources;
using CsharpStudy.DtoMapper.Mappers;
using CsharpStudy.DtoMapper.Models;

namespace CsharpStudy.DtoMapper.Repositories;

public class PokemonRepository : IPokemonRepository
{
    private IPokemonApiDataSource _dataSource;

    public PokemonRepository(IPokemonApiDataSource dataSource)
    {
        _dataSource = dataSource;
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
                    return new Result<Pokemon, PokemonError>.Error(PokemonError.UnknownError);
            }
        }
        catch (Exception e)
        {
            return new Result<Pokemon, PokemonError>.Error(PokemonError.NetworkError);
        }
    }
}