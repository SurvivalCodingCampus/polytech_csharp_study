using System.Net.Http;
using System.Threading.Tasks;
using CsharpStudy.Http.Pokemon.DataSource;
using CsharpStudy.Http.Pokemon.Repositories;
using NUnit.Framework;

namespace CsharpStudy.Http.Poketmon.Tests.Repositories;

[TestFixture]
[TestOf(typeof(PokemonRepository))]
public class PokemonRepositoryTest
{
    [Test]
    public async Task Poketmon_GET_Test()
    {
        IPokemonRepository repository = new PokemonRepository(new PokemonApiDataSource(new HttpClient()));
        Pokemon.Models.Pokemon pokemon = await repository.GetPokemonByNameAsync("ditto"); // 네임스페이스.클래스이름 변수이름 = ...
        // 디토라는 포켓몬 정보 주세요! 
        Assert.That(pokemon.Name, Is.EqualTo("ditto"));
        Assert.That(pokemon.Sprites.Other.OfficialArtwork.FrontDefault,
            Is.EqualTo(
                "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/132.png"));
    }
}