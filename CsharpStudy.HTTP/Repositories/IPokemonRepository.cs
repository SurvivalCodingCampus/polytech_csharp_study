using CsharpStudy.HTTP.Common;
using CsharpStudy.HTTP.DTOs;

namespace CsharpStudy.HTTP.Repositories;

public interface IPokemonRepository
{
    Task<(Result result, PokemonDto? data)> GetByNameAsync(string name);
}