using CsharpStudy.Network.DTOs;
using CsharpStudy.Network.Interfaces;
using CsharpStudy.Network.Mappers;
using CsharpStudy.Network.Models;

namespace CsharpStudy.Network.Repositories;

public class PokemonRepository(IDataSource<PokemonDto> dataSource) : IRepository<Result<Pokemon, Error>>
{
    private IDataSource<PokemonDto> _dataSource = dataSource;

    public async Task<Result<Pokemon, Error>> GetByNameAsync(string name)
    {
        try
        {
            var response = await _dataSource.GetNameAsync(name);

            switch (response.StatusCode)
            {
                case 200:
                    return new Result<Pokemon, Error>.Success(Mapper.ToModel(response.Body));
                case 404:
                    return new Result<Pokemon, Error>.Error(Error.NotFound);
                case -1:
                    return new Result<Pokemon, Error>.Error(Error.NetworkTimeout);
                default:
                    return new Result<Pokemon, Error>.Error(Error.Unknown);
            }
        }
        catch (Exception e)
        {
            return new Result<Pokemon, Error>.Error(Error.Unknown);
        }
    }
}