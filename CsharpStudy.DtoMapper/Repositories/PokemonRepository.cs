using CsharpStudy.DtoMapper.DataSources;
using CsharpStudy.DtoMapper.DTOs;
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
        try  // 에러타입 받아주기
        {
            Response<PokemonDto> response = await _dataSource.GetPokemonAsync(pokemonName);

            switch (response.StatusCode)
            {
                case 200:
                    return new Result<Pokemon, PokemonError>.Success(response.Body.ToModel());
                case 404:
                    return new Result<Pokemon, PokemonError>.Error(PokemonError.NotFound);
                case 408:
                    return new Result<Pokemon, PokemonError>.Error(PokemonError.Timeout);
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