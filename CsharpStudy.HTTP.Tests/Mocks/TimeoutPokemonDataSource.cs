using System;
using System.Threading.Tasks;
using CsharpStudy.HTTP.DataSources;
using CsharpStudy.HTTP.DTOs;

namespace CsharpStudy.HTTP.Tests.Mocks 
{
    public sealed class TimeoutPokemonDataSource : IPokemonApiDataSource
    {
        public Task<PokemonDto?> GetPokemonAsync(string name)
            => throw new TimeoutException("Mock Timeout");
    }
}