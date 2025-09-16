using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CsharpStudy.DtoMapper.DataSources;
using CsharpStudy.DtoMapper.Models;
//using CsharpStudy.DtoMapper.DTO; // PokemonDto
using CsharpStudy.DtoMapper.Repositories;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CsharpStudy.DtoMapper.Tests.DataSources;

[TestFixture]
[TestOf(typeof(PokemonApiDataSource))]
public class PokemonApiDataSourceTest
{
    [Test]
    public async Task PokemonApiDataSource_Test()
    {
        IPokemonApiDataSource dataSource = new PokemonApiDataSource(new HttpClient());
        // 실제 네트워크 통신 기능 HttpClient 사용해 PokemonApiDataSource의 인스턴스(객체)를 만듦 ->  실제로 인터넷을 통해 API 서버에 접속
        var response = await dataSource.GetPokemonAsync("ditto"); // PokeAPI 서버에 "ditto"에 대한 정보를 요청

        Assert.That(response.StatusCode, Is.EqualTo(200));

        PokemonDto pokemonDto = response.Body; // 포켓몬의 모든 정보 담긴 객체만 추출해 변수에 저장 
        Assert.That(pokemonDto.Name, Is.EqualTo("ditto"));
        Assert.That(pokemonDto?.Sprites?.Other?.OfficialArtwork?.FrontDefault, Is.EqualTo(
            "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/132.png"));
    }
}