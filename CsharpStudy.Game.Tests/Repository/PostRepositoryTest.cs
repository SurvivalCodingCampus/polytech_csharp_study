using System.Net.Http;
using System.Threading.Tasks;
using CsharpStudy.HttpStudy.Data;
using CsharpStudy.HttpStudy.Repository;
using NUnit.Framework;

namespace CsharpStudy.Game.Tests.Repository;

[TestFixture]
[TestOf(typeof(PostRepository))]
public class PostRepositoryTest
{

    [Test]
    public async Task pokemonTest()
    {
        HttpClient httpClient = new HttpClient();
        IPokemonApiDataSource<Pokemon> dataSource = new RemotePostDataSource(httpClient);
        IPokemonRepository postRepository = new PostRepository(dataSource);
        Pokemon pokemon = await postRepository.GetPokemonByNameAsync("Snorlax");
        Assert.That(pokemon,Is.Not.Null);
    }
}