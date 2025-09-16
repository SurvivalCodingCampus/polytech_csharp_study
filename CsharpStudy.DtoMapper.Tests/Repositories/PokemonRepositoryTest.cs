using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CsharpStudy.DtoMapper.Common;
using CsharpStudy.DtoMapper.DataSources;
using CsharpStudy.DtoMapper.DTOs;
using CsharpStudy.DtoMapper.Models;
using CsharpStudy.DtoMapper.Repositories;
using NUnit.Framework;

namespace CsharpStudy.DtoMapper.Tests.Repositories;

[TestFixture]
[TestOf(typeof(PokemonRepository))]
public class PokemonRepositoryTest
{
    [Test]
    public async Task Result_Test()
    {
        IPokemonRepository repository = new PokemonRepository(new PokemonApiDataSource(new HttpClient()));

        Result<Pokemon, PokemonError> result = await repository.GetPokemonByNameAsync("ditto");

        Assert.That(result is Result<Pokemon, PokemonError>.Success, Is.True);

        Pokemon pokemon = (result as Result<Pokemon, PokemonError>.Success)!.data;
        Assert.That(pokemon.Name, Is.EqualTo("ditto"));
    }

    [Test]
    public async Task Result_Fail_Test()
    {
        IPokemonRepository repository = new PokemonRepository(new MockErrorDataSource());

        // 404
        Result<Pokemon, PokemonError> result = await repository.GetPokemonByNameAsync("404");

        Assert.That(result is Result<Pokemon, PokemonError>.Error, Is.True);

        PokemonError error = (result as Result<Pokemon, PokemonError>.Error)!.error;
        Assert.That(error == PokemonError.NotFound, Is.True);
        
        // NetworkError
        result = await repository.GetPokemonByNameAsync("NetworkError");

        Assert.That(result is Result<Pokemon, PokemonError>.Error, Is.True);

        error = (result as Result<Pokemon, PokemonError>.Error)!.error;
        Assert.That(error == PokemonError.NetworkError, Is.True);
        
        // UnknownError
        result = await repository.GetPokemonByNameAsync("1111");

        Assert.That(result is Result<Pokemon, PokemonError>.Error, Is.True);

        error = (result as Result<Pokemon, PokemonError>.Error)!.error;
        Assert.That(error == PokemonError.UnknownError, Is.True);
    }

    class MockErrorDataSource : IPokemonApiDataSource
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
}