using CsharpStudy.Network.DTOs;
using CsharpStudy.Network.Interfaces;
using CsharpStudy.Network.Mappers;
using CsharpStudy.Network.Models;
using Newtonsoft.Json;

namespace CsharpStudy.Network.Repositories;

public enum PokemonApiError
{
    NetworkTimeout,
    NotFound,
    Unknown,
    AuthenticationFailed,
    JsonSerialization,
    BadRequest,
}

public class PokemonRepository(IDataSource<PokemonDto> dataSource) : IRepository<Result<Pokemon, PokemonApiError>>
{
    private IDataSource<PokemonDto> _dataSource = dataSource;

    public async Task<Result<Pokemon, PokemonApiError>> GetByNameAsync(string name)
    {
        try
        {
            var response = await _dataSource.GetNameAsync(name);

            switch (response.StatusCode)
            {
                case 200:
                    return new Result<Pokemon, PokemonApiError>.Success(PokemonMapper.ToModel(response.Body));
                case 400:
                    return new Result<Pokemon, PokemonApiError>.Error(PokemonApiError.BadRequest);
                case 404:
                    return new Result<Pokemon, PokemonApiError>.Error(PokemonApiError.NotFound);
                case 408:
                    return new Result<Pokemon, PokemonApiError>.Error(PokemonApiError.NetworkTimeout);
                default:
                    return new Result<Pokemon, PokemonApiError>.Error(PokemonApiError.Unknown);
            }
        }
        catch (JsonSerializationException e)
        {
            return new Result<Pokemon, PokemonApiError>.Error(PokemonApiError.JsonSerialization);
        }
        catch (Exception e)
        {
            return new Result<Pokemon, PokemonApiError>.Error(PokemonApiError.Unknown);
        }
    }
}