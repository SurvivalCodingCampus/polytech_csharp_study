using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CsharpStudy.DtoMapper.Common;
using CsharpStudy.DtoMapper.Repositories;
using CsharpStudy.Result.DataSources;
using CsharpStudy.Result.Models;
using CsharpStudy.Result.Repositories;
using NUnit.Framework;

namespace CsharpStudy.Result.Tests.Repositories;

[TestFixture]
[TestOf(typeof(PokemonRepository))]
public class PokemonRepositoryTest
{
    [Test]
    public async Task Result_TImeoutDataSource_Test()
    {
        IPokemonRepository repository = new PokemonRepository(new MockErrorDataSource());

        // TimeoutError
        Result<Pokemon, PokemonError> result = await repository.GetPokemonByNameAsync("Timeout");
        Assert.That(result is Result<Pokemon, PokemonError>.Error, Is.True);
        PokemonError error = (result as Result<Pokemon, PokemonError>.Error)!.error;
        Assert.That(error == PokemonError.TimeoutException, Is.True);

        // JsonSerializationError
        result = await repository.GetPokemonByNameAsync("JsonSerializationError");

        Assert.That(result is Result<Pokemon, PokemonError>.Error, Is.True);

        error = (result as Result<Pokemon, PokemonError>.Error)!.error;
        Assert.That(error == PokemonError.JsonSerializationException, Is.True);
    }
}

class MockErrorDataSource : IPokemonApiDataSource
{
    public async Task<Response<PokemonDto>> GetPokemonAsync(string pokemonName)
    {
        if (pokemonName == "Timeout")
        {
            //await Task.Delay(Timeout.Infinite);
            throw new InvalidOperationException("AlwaysTimeoutError");
        }

        if (pokemonName == "JsonSerializationError")
        {
            // string malformedJson =
            //     @"{ ""name"": ""Pikachu"" ""type"": ""Electric"" }"; // 가짜 데이터 (문자열): type 속성 앞에 쉼표(,)가 빠져있음
            throw new ArgumentException("AlwaysJsonSerializationError");
        }

        //throw new System.NotImplementedException();
        return new Response<PokemonDto>(
            -1,
            new Dictionary<string, string>(),
            new PokemonDto()
        );
    }
}