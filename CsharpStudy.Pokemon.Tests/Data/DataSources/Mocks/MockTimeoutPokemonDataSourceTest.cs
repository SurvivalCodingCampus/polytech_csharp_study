using System.Net.Http;
using System.Threading.Tasks;
using CsharpStudy.DTO.Data.Common;
using CsharpStudy.DTO.Data.DataSources.Mocks;
using CsharpStudy.DTO.Data.Repositories;
using NUnit.Framework;

namespace CsharpStudy.Pokemon.Tests.Data.DataSources.Mocks;

[TestFixture]
[TestOf(typeof(MockTimeoutPokemonDataSource))]
public class MockTimeoutPokemonDataSourceTest
{

    [Test]
    public async Task DATASOURCE_SENDING_TIMEOUT()
    {
        IPokemonRepository repository = new PokemonRepository(new MockTimeoutPokemonDataSource(new HttpClient()));

        Result<DTO.Data.Models.Pokemon?, PokemonError> result = await repository.GetPokemonByNameAsync("dittooo");

        Assert.That(result, Is.InstanceOf<Result<DTO.Data.Models.Pokemon?, PokemonError>.Error>());
        var errorResult = result as Result<DTO.Data.Models.Pokemon?, PokemonError>.Error;
        
        Assert.That(errorResult._Error, Is.EqualTo(PokemonError.NetworkTimeout));
    }
    
    [Test]
    public async Task DATASOURCE_SENDING_SERIALIZEFAIL()
    {
        IPokemonRepository repository = new PokemonRepository(new MockSerializeFailPokemonDataSource(new HttpClient()));

        Result<DTO.Data.Models.Pokemon?, PokemonError> result = await repository.GetPokemonByNameAsync("dittooo");

        Assert.That(result, Is.InstanceOf<Result<DTO.Data.Models.Pokemon?, PokemonError>.Error>());
        var errorResult = result as Result<DTO.Data.Models.Pokemon?, PokemonError>.Error;
        
        Assert.That(errorResult._Error, Is.EqualTo(PokemonError.JsonSerializationFailed));
    }
}