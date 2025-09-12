using System.Net.Http;
using System.Threading.Tasks;
using Csharp_study.http.DataSources;
using Csharp_study.http.Model;
using NUnit.Framework;

namespace CsharpStudy.Game.Tests.DataSources;

[TestFixture]
[TestOf(typeof(RemotePokemonDataSource))]
public class RemotePokemonDataSourceTest
{

    [Test]
    public async Task Post_GET_Test()
    {
        IPokemonApiDataSource<Pokemon> dataSource = new RemotePokemonDataSource(new HttpClient());
        var response = await dataSource.GetPokemonAsync("ditto");
        
        Assert.That("ditto", Is.EqualTo("ditto"));
    }
}