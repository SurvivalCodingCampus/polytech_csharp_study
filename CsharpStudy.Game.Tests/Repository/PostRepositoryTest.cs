using System.Net.Http;
using System.Threading.Tasks;
using CsharpStudy.HttpStudy.Data;
using CsharpStudy.HttpStudy.DTO;
using CsharpStudy.HttpStudy.Mapper;
using CsharpStudy.HttpStudy.Repository;
using NUnit.Framework;

namespace CsharpStudy.Game.Tests.Repository;

[TestFixture]
[TestOf(typeof(PostRepository))]
public class PostRepositoryTest
{

    [Test]
    public async Task PokemonTest()
    {
        /*
         HttpClient httpClient = new HttpClient();
        IPokemonApiDataSource<Pokemon> dataSource = new RemotePostDataSource(httpClient);
        IPokemonRepository postRepository = new PostRepository(dataSource);
        Pokemon pokemon = await postRepository.GetPokemonByNameAsync("Snorlax");
        Assert.That(pokemon,Is.Not.Null);
        */
    }

    [Test]
    public async Task PokemonManpperTest()
    {
        HttpClient httpClient = new HttpClient();
        IPokemonApiDataSource<Pokemon> dataSource = new RemotePostDataSource(httpClient); //데이터 만들기
        IPokemonRepository postRepository = new PostRepository(dataSource); //레포 생성
        
        Pokemon pokemon = await postRepository.GetPokemonByNameAsync("snorlax"); // GetPokemonByNameAsync 함수 실행해서 데이터를 DTO로 넣음
        
        
        Assert.That(pokemon.Name, Is.EqualTo("snorlax"));
    }


}