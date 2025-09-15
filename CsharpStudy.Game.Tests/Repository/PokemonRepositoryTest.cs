using System.Net.Http;
using System.Threading.Tasks;
using CsharpStudy.HttpPokeMon.DataSources;
using CsharpStudy.HttpPokeMon.Models;
using CsharpStudy.HttpPokeMon.Repository;
using NUnit.Framework;

namespace CsharpStudy.Game.Tests.Repository;

[TestFixture]
[TestOf(typeof(PokemonRepository<>))]
public class PokemonRepositoryTest
{


    [Test]
    public async Task test()
    {
        IPokemonApiDataSource<Pokemon> dataSource = new RemotPokemonDataSource(new HttpClient());
        var response = await dataSource.GetPokemonAsync("ditto");

        Assert.That(response.Body, Is.Not.Null);
        Assert.That(response.Body.Name, Is.EqualTo("ditto"));
    }
}