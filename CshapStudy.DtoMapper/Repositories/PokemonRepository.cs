using CshapStudy.DtoMapper.Common;
using CshapStudy.DtoMapper.DataSource;
using CshapStudy.DtoMapper.Mappers;
using CshapStudy.DtoMapper.Models;

namespace CshapStudy.DtoMapper.Repositories;

public class PokemonRepository : IPokemonRepository
{
    private IPokemonApiDataSource _dataSource;

    public PokemonRepository(IPokemonApiDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public async Task<Result<Pokemon,PoKemonError>> GetPokemonByNameAsync(string pokemonName)
    {
        if (String.IsNullOrWhiteSpace(pokemonName))
        {
            return new Result<Pokemon, PoKemonError>.Error(PoKemonError.InvalidInput);
        }
        try
        {
            var response = await _dataSource.GetPokemonAsync(pokemonName);

        switch (response.StatusCode)
        {
            case 200:
                var dto = response.Body;
                Pokemon pokemon = dto.ToModel();
                return new Result<Pokemon, PoKemonError>.Success(pokemon);
            case 404:
                return new Result<Pokemon, PoKemonError>.Error(PoKemonError.NotFound);
            default:
                return new Result<Pokemon, PoKemonError>.Error(PoKemonError.UnknownError);
        }
    }
        catch (Exception e)
        {

            return new Result<Pokemon, PoKemonError>.Error(PoKemonError.UnknownError);



        }
    }
}