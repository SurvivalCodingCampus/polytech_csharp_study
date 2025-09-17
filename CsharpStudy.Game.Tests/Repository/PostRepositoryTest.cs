using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CsharpStudy.HttpStudy.Common;
using CsharpStudy.HttpStudy.Data;
using CsharpStudy.HttpStudy.DataSources;
using CsharpStudy.HttpStudy.DTO;
using CsharpStudy.HttpStudy.Mapper;
using CsharpStudy.HttpStudy.Repository;
using NUnit.Framework;
using Newtonsoft.Json;



namespace CsharpStudy.Game.Tests.Repository;

[TestFixture]
[TestOf(typeof(PostRepository))]
public class PostRepositoryTest
{
    
    [Test]
    public async Task PokemonTest()
    {
        HttpClient httpClient = new HttpClient();
        IPokemonApiDataSource dataSource = new RemotePostDataSource(httpClient); //데이터 만들기
        IPokemonRepository postRepository = new PostRepository(dataSource); //레포 생성
        
        Result<Pokemon, PokemonError> pokemon = await postRepository.GetPokemonByNameAsync("dittooo"); // GetPokemonByNameAsync 함수 실행해서 데이터를 DTO로 넣음
        
        //Assert.That(pokemon, Is.True);
        Assert.That(pokemon is Result<Pokemon, PokemonError>.Error(PokemonError.NotFound), Is.True);
    }
    
    [Test]
    public async Task Result_Fail_Test()
    {
        IPokemonRepository repository = new PostRepository(new MockErrorDataSource());

        // TimeoutException
        Result<Pokemon, PokemonError> result = await repository.GetPokemonByNameAsync("-99");

        Assert.That(result is Result<Pokemon, PokemonError>.Error, Is.True);

        PokemonError error = (result as Result<Pokemon, PokemonError>.Error)!.error;
        Assert.That(error == PokemonError.TimeoutException, Is.True);
        
        //JsonSerializationException
        Result<Pokemon, PokemonError> _result = await repository.GetPokemonByNameAsync("-98");

        Assert.That(_result is Result<Pokemon, PokemonError>.Error, Is.True);

        PokemonError _error = (_result as Result<Pokemon, PokemonError>.Error)!.error;
        Assert.That(_error == PokemonError.JsonSerializationException, Is.True);
        
        
    }
    
    class MockErrorDataSource : IPokemonApiDataSource
    {
        public async Task<Response<PokemonDto>> GetPokemonAsync(string pokemonName)
        {
            if (pokemonName == "-99")
            {
                return new Response<PokemonDto>(
                    -99,
                    new Dictionary<string, string>(),
                    new PokemonDto()
                );
            }

            return new Response<PokemonDto>(
                -98,
                new Dictionary<string, string>(),
                new PokemonDto()
            );
        }
    }
    
    
    
}