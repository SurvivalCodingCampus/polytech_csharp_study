using CsharpStudy.Network.DTOs;
using CsharpStudy.Network.Interfaces;
using CsharpStudy.Network.Mappers;
using CsharpStudy.Network.Models;

namespace CsharpStudy.Network.Repositories;

public class PokemonRepository(IDataSource<PokemonDto> dataSource) : IRepository<Pokemon>
{
    private IDataSource<PokemonDto> _dataSource = dataSource;

    public async Task<Pokemon> GetByNameAsync(string name)
    {
        var response = await _dataSource.GetNameAsync(name);
        return Mapper.ToModel(response.Body);
    }
}