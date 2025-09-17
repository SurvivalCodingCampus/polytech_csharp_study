using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Csharp_study.http.Model;
using CsharpStudy.DTO.Common;
using CsharpStudy.DTO.DataSources;
using CsharpStudy.DTO.DTOs;
using CsharpStudy.DTO.Mapper;
using CsharpStudy.DTO.Repositories;
using NUnit.Framework;
using Pokemon = CsharpStudy.DTO.Model.Pokemon;

namespace CsharpStudy.Game.MapperTests.Mapper;

[TestFixture]
[TestOf(typeof(PokemonMapper))]
public class PokemonMapperTest
{

    [Test]
    public void Mapper검증()
    {
        var dto = new PokemonDto
        {
            Name = "ditto",
            Sprites = new SpritesDto
            {
                Other = new OtherDto
                {
                    OfficialArtwork = new OfficialArtworkDto
                    {
                        FrontDefault =
                            "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/132.png"
                    }
                }
            }
        };
        
        var model = dto.ToModel();
        
        Assert.That(model.Name, Is.EqualTo("ditto"));
        Assert.That(model.ImageUrl, Is.EqualTo("https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/132.png"));
    }

    [Test]
    public void 이름이_null일_때_빈_문자열로_처리하는지_확인하는_테스트()
    {
        var dto = new PokemonDto
        {
            Name = null,
            Sprites = null
        };
        var model = dto.ToModel();
        Assert.That(model.Name, Is.EqualTo(""));
    }

    [Test]
    public void 이름이_이미_빈_문자열_일_때_그대로_반환하는지_테스트()
    {
        var dto = new PokemonDto
        {
            Name = "",
            Sprites = null
        };
        var model = dto.ToModel();
        Assert.That(model.Name, Is.EqualTo(""));
    }

    [Test]
    public async Task Result_Test()
    {
        IPokemonRepository repository = new PokemonRespository(new PokemonApiDataSource(new HttpClient()));
        Result<Pokemon, PokemonError> result = await repository.GetPokemonByNameAsync("ditto");
        
        Assert.That(result is Result<Pokemon, PokemonError>.Success, Is.True);

        Pokemon pokemon = (result as Result<Pokemon, PokemonError>.Success)!.data;
        Assert.That(pokemon.Name, Is.EqualTo("ditto"));


    }
    [Test]
    public async Task Result_Fail_Test()
    {
        IPokemonRepository repository = new PokemonRespository(new MockErrorDataSoure());
        Result<Pokemon, PokemonError> result = await repository.GetPokemonByNameAsync("404");
        Assert.That(result is Result<Pokemon, PokemonError>.Error, Is.True);

        PokemonError error = (result as Result<Pokemon, PokemonError>.Error)!.eror;
        Assert.That(error == PokemonError.NotFound, Is.True);
        
        result = await repository.GetPokemonByNameAsync("NetworkError");
        Assert.That(result is Result<Pokemon, PokemonError>.Error, Is.True);
        
        error = (result as Result<Pokemon, PokemonError>.Error)!.eror;
        Assert.That(error == PokemonError.NetworkError, Is.True);
        
        result = await repository.GetPokemonByNameAsync("1111");
        Assert.That(result is Result<Pokemon, PokemonError>.Error, Is.True);
        
        error = (result as Result<Pokemon, PokemonError>.Error)!.eror;
        Assert.That(error == PokemonError.UnkonwnError, Is.True);
    }
}

public class MockErrorDataSoure : IPokemonApiDataSource
{
    public async Task<Response<PokemonDto>> GetPokemonAsync(string pokemonName)
    {
        if (pokemonName == "404")
        {
            return new Response<PokemonDto>(
                404,
                new Dictionary<string, string>(),
                new PokemonDto()
            );
        }

        if (pokemonName == "NetworkError")
        {
            throw new ArgumentException("NetworkError");
        }

        return new Response<PokemonDto>(
            -1,
            new Dictionary<string, string>(),
            new PokemonDto()
        );
    }

    
}



