using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using CshapStudy.DtoMapper.Common;
using CshapStudy.DtoMapper.DataSource;
using CshapStudy.DtoMapper.DTOs;
using CshapStudy.DtoMapper.Models;
using CshapStudy.DtoMapper.Repositories;
using NUnit.Framework;

namespace CsharpStudy.DtoTest.Repositories;

[TestFixture]
[TestOf(typeof(PokemonRepository))]
public class PokemonRepositoryTest
{
    [Test]
    public async Task Result_Test()
    {
        IPokemonRepository repository = new PokemonRepository(new PokemonApiDataSource(new HttpClient()));

        Result<Pokemon, PoKemonError> result = await repository.GetPokemonByNameAsync("ditto");

        Assert.That(result is Result<Pokemon, PoKemonError>.Success, Is.True);

        Pokemon pokemon = (result as Result<Pokemon, PoKemonError>.Success)!.data;
        Assert.That(pokemon.Name, Is.EqualTo("ditto"));
    }

    [Test]
    public async Task Result_Fail_Test()
    {
        IPokemonRepository repository = new PokemonRepository(new MockTimeoutDataSource());
        Result<Pokemon, PoKemonError> result = await repository.GetPokemonByNameAsync("dittoo");
        Assert.That(result is Result<Pokemon, PoKemonError>.Error, Is.False);
      
        result = await repository.GetPokemonByNameAsync("timeout");
        var errorResult = result as Result<Pokemon, PoKemonError>.Error;
        Assert.That(errorResult!.error == PoKemonError.UnknownError, Is.True);
        
        await repository.GetPokemonByNameAsync("serialization-error");
        Assert.That(errorResult!.error == PoKemonError.UnknownError, Is.True);

         
         
    
    }


}

public class MockTimeoutDataSource : IPokemonApiDataSource
{
    public async Task<Response<PokemonDto>> GetPokemonAsync(string pokemonName)
    {
        if (pokemonName == "timeout")
        {
            //항상 타임아웃(TimeoutException)발생하는 MockDataSource작성
            throw new TimeoutException("항상 타임아웃(TimeoutException)발생하는 MockDataSource작성");
        }
        else if (pokemonName == "serialization-error")
        {
            //항상 타임아웃(JsonSerilzationException)발생하는 MocDataSource작성
            throw new JsonException("항상 타임아웃(JsonSerilzationException)발생하는 MocDataSource작성");
        }

        // 필요시 에러타입 추가 
        return new Response<PokemonDto>(200, new { }, new PokemonDto { Name = "ditt" });
    }
}