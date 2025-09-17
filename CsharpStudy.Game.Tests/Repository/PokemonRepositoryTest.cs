using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using CsharpStudy.HttpPokeMon;
using CsharpStudy.HttpPokeMon.Common;
using CsharpStudy.HttpPokeMon.DataSources;
using CsharpStudy.HttpPokeMon.DTO;
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
        // RemotPokemonDataSource dataSource = new RemotPokemonDataSource(new HttpClient());
        // var response = await dataSource.GetPokemonAsync("ditto");
        //
        // Assert.That(response.Body, Is.Not.Null);
        // Assert.That(response.Body.Name, Is.EqualTo("ditto"));
        //
        IPokemonApiDataSource<PokemonDTO> dataSource = new RemotPokemonDataSource(new HttpClient());
        PokemonRepository<PokemonDTO> pokemonRepository = new PokemonRepository<PokemonDTO>(dataSource);

        var result = await pokemonRepository.GetPokemonByNameAsync("ditto");
        
        Assert.That(result, Is.Not.Null);
        // Assert.That(result.Name, Is.EqualTo("ditto"));
        // Assert.That(result.ImageUrl, Is.Not.Null);
    }
    
    // 오류 해결을 위함 test코드
    // 중첩 클래스로 인한 오류... 
    // 속성을 반환하는 코드에서도 중첩 클래스는 xx null 값이 들어가게 됨
    [Test]
    public async Task TestDataSourceDirectly()
    {
        IPokemonApiDataSource<PokemonDTO> dataSource = new RemotPokemonDataSource(new HttpClient());
        var response = await dataSource.GetPokemonAsync("ditto");
    
        Console.WriteLine($"Response is null: {response == null}");
        Console.WriteLine($"Response.Body is null: {response?.Body == null}");
        Console.WriteLine($"Name: {response?.Body?.Name}");
        Console.WriteLine($"Sprites: {response?.Body?.Sprites}");
    }
    
    [Test]
    public async Task TestSpritesContent()
    {
        RemotPokemonDataSource dataSource = new RemotPokemonDataSource(new HttpClient());
        var response = await dataSource.GetPokemonAsync("ditto");
    
        var sprites = response.Body.Sprites;
        Console.WriteLine($"Sprites.FrontDefault: {sprites?.FrontDefault}");
        Console.WriteLine($"Sprites.Other is null: {sprites?.Other == null}");
    
        if (sprites?.Other != null)
        {
            Console.WriteLine($"Other.OfficialArtwork is null: {sprites.Other.OfficialArtwork == null}");
            if (sprites.Other.OfficialArtwork != null)
            {
                Console.WriteLine($"OfficialArtwork.FrontDefault: {sprites.Other.OfficialArtwork.FrontDefault}");
            }
        }
    }
    [Test] 
    public async Task DebugOtherSprites()
    {
        RemotPokemonDataSource dataSource = new RemotPokemonDataSource(new HttpClient());
        var response = await dataSource.GetPokemonAsync("ditto");
    
        // Other 객체를 JsonElement로 확인
        var sprites = response.Body.Sprites;
        Console.WriteLine($"Other type: {sprites?.Other?.GetType()}");
    
        // 또는 이렇게 확인
        Console.WriteLine("=== Sprites JSON 구조 확인 ===");
        Console.WriteLine(JsonSerializer.Serialize(sprites, new JsonSerializerOptions { WriteIndented = true }));
    }
    [Test]
    public async Task CheckRawApiResponse()
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync("https://pokeapi.co/api/v2/pokemon/ditto");
        var jsonString = await response.Content.ReadAsStringAsync();
    
        Console.WriteLine("=== RAW API RESPONSE ===");
        Console.WriteLine(jsonString);
    
        // 또는 sprites 부분만 확인
        var jsonDoc = JsonDocument.Parse(jsonString);
        if (jsonDoc.RootElement.TryGetProperty("sprites", out var spritesElement))
        { Console.WriteLine(spritesElement.GetRawText());
        }
    }

    [Test]
    public async Task NotFound_Pokemon()
    {        
        IPokemonApiDataSource<PokemonDTO> dataSource = new RemotPokemonDataSource(new HttpClient());
        PokemonRepository<PokemonDTO> pokemonRepository = new PokemonRepository<PokemonDTO>(dataSource);

        var result = await pokemonRepository.GetPokemonByNameAsync("dittooo");

        switch (result)
        {
            case Result<Pokemon, PokemonError>.Success pokemonResult:
                Console.WriteLine($"포케몬 이름: {pokemonResult.data.Name}");
                Console.WriteLine($"이미지URL: {pokemonResult.data.ImageUrl}");
                break;
            case Result<Pokemon, PokemonError>.Error pokemonError:
                switch (pokemonError.error)
                {
                    case PokemonError.NotFound:
                        Console.WriteLine("오류: 해당 포켓몬을 찾을 수 없습니다.");
                        break;
                    case PokemonError.NetworkTimeout:
                        Console.WriteLine("오류: 네트워크 연결 시간 초과.");
                        break;
                    default:
                        Console.WriteLine("알 수 없는 오류가 발생했습니다");
                        break;
                }
            break;
        }
    }
    
    [Test]
    public async Task Timeout_Pokemon()
    {        
        IPokemonApiDataSource<PokemonDTO> dataSource = new MockErrorDataSource();
        PokemonRepository<PokemonDTO> pokemonRepository = new PokemonRepository<PokemonDTO>(dataSource);

        var result = await pokemonRepository.GetPokemonByNameAsync("-1");

        switch (result)
        {
            case Result<Pokemon, PokemonError>.Success pokemonResult:
                Console.WriteLine($"포케몬 이름: {pokemonResult.data.Name}");
                Console.WriteLine($"이미지URL: {pokemonResult.data.ImageUrl}");
                break;
            case Result<Pokemon, PokemonError>.Error pokemonError:
                switch (pokemonError.error)
                {
                    case PokemonError.NotFound:
                        Console.WriteLine("오류: 해당 포켓몬을 찾을 수 없습니다.");
                        break;
                    case PokemonError.NetworkTimeout:
                        Console.WriteLine("오류: 네트워크 연결 시간 초과.");
                        break;
                    default:
                        Console.WriteLine("알 수 없는 오류가 발생했습니다");
                        break;
                }
                break;
        }
    }

    class MockErrorDataSource : IPokemonApiDataSource<PokemonDTO>
    {
        public async Task<Response<PokemonDTO>> GetPokemonAsync(string pokemonName)
        {
            if (pokemonName == "-1")
            {
                return new Response<PokemonDTO>(
                    statusCode: -1,
                    headers: null,
                    body: null
                );
            }
            return new Response<PokemonDTO?>(
                statusCode: 0,
                headers: null,
                body: null
            );
        }
    }
}