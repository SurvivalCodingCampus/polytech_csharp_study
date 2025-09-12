using System.Net.Http;
using System.Threading.Tasks;
using CsharpStudy.Http.DataSources;
using CsharpStudy.Http.Models;
using NUnit.Framework;

namespace CsharpStudy.Http.Tests.DataSources;

[TestFixture]
[TestOf(typeof(RemotePokemonDataSource))]
public class RemotePokemonDataSourceTest
{
    [Test]
    public async Task Pokemon_GET_Test()
    {
        string pokemonName = "ditto";
        
        IPokemonApiDataSource<Pokemon> dataSource = new RemotePokemonDataSource(new HttpClient());
        var response = await dataSource.GetPokemonAsync(pokemonName);
        
        Assert.That(response.StatusCode, Is.EqualTo(200));
        Assert.That(response, Is.Not.Null);
        Assert.That(response.Body.Name, Is.EqualTo(pokemonName).IgnoreCase);
    }
}