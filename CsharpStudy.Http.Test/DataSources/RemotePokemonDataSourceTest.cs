using System.Net.Http;
using System.Threading.Tasks;
using CsharpStudy.Http.DataSources;
using CsharpStudy.Http.Models;
using NUnit.Framework;

namespace CsharpStudy.Http.Test.DataSources;

[TestFixture]
[TestOf(typeof(RemotePokemonDataSource))]
public class RemotePokemonDataSourceTest
{

    [Test]
    public async Task Get_Pokemon_Name()
    {
        var dataSource = new RemotePokemonDataSource(new HttpClient());
        var response = await dataSource.GetPokemonAsync("pikachu");
        
        Assert.That(response.Body.Name, Is.EqualTo("pikachu"));
    }
}