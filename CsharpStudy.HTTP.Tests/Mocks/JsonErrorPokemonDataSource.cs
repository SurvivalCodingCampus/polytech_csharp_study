using System.Threading.Tasks;
using Newtonsoft.Json;
using CsharpStudy.HTTP.DataSources;
using CsharpStudy.HTTP.DTOs;

namespace CsharpStudy.HTTP.Tests.Mocks  
{
    public sealed class JsonErrorPokemonDataSource : IPokemonApiDataSource
    {
        public Task<PokemonDto?> GetPokemonAsync(string name)
            => throw new JsonSerializationException("Mock JSON error");
    }
}