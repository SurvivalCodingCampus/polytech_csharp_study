using System.Net.Http;
using System.Threading.Tasks;
using CsharpStudy.Http.DataSources;
using CsharpStudy.Http.Repositories;
using NUnit.Framework;

namespace CsharpStudy.Http.Tests.Repositories;

[TestFixture]
[TestOf(typeof(PokemonRepository))]
public class PokemonRepositoryTest
{

    [Test]
    public async Task Pokemon_Get()
    {
        var dataSource = new RemotePokemonAPIDataSource(new HttpClient());
        var repository = new PokemonRepository(dataSource);
        var pokemon = await repository.GetPokemonByNameAsync("ditto");
        
        Assert.That(pokemon, Is.Not.Null);
        Assert.That(pokemon!.Name, Is.EqualTo("ditto"));
    }
}