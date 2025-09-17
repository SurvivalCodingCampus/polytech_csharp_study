using System;
using System.ComponentModel;
using System.Threading.Tasks;
using CsharpStudy.Network.Datasources;
using CsharpStudy.Network.DTOs;
using CsharpStudy.Network.Interfaces;
using CsharpStudy.Network.Mappers;
using CsharpStudy.Network.Models;
using CsharpStudy.Network.Repositories;
using NUnit.Framework;

namespace CsharpStudy.Network.Test.Repositories;

[TestFixture]
[TestOf(typeof(PokemonRepository))]
public class PokemonRepositoryTest
{
    private IDataSource<PokemonDto> _dataSource;
    private IRepository<Result<Pokemon, PokemonApiError>> _repository;

    [SetUp]
    protected void Setup()
    {
        _dataSource = new PokemonApiDatasource();
        _repository = new PokemonRepository(_dataSource);
    }


    [Test]
    [DisplayName("PokemonDto -> Pokemon 변환 테스트")]
    public void Method_3()
    {
        //given
        PokemonDto pokemonDto = new PokemonDto();
        pokemonDto.Id = 1;
        pokemonDto.Name = "picachu";
        pokemonDto.Sprites = new Sprites();
        pokemonDto.Sprites.FrontDefault = "picachuImg";
        //when

        var pokemon = PokemonMapper.ToModel(pokemonDto);

        //then
        Assert.AreEqual(pokemon.Id, pokemonDto.Id);
        Assert.AreEqual(pokemon.Name, pokemonDto.Name);
        Assert.AreEqual(pokemon.Image, pokemonDto.Sprites.FrontDefault);
    }


    [Test]
    [DisplayName("API 통신 성공하여 200 코드가 반환된다.")]
    public async Task Method_2()
    {
        //given
        string name = "pikachu";

        //when
        var response = await _dataSource.GetNameAsync(name);

        //then
        Assert.IsNotNull(response);
        Assert.AreEqual(response.StatusCode, 200);
    }

    [Test]
    [DisplayName("포켓몬 정상적인 정보를 Repository에서 가지고 온다.")]
    public async Task Method_1()
    {
        //given
        string name = "pikachu";

        //when
        Result<Pokemon, PokemonApiError> result = await _repository.GetByNameAsync(name);

        //then
        Assert.IsNotNull(result);
        Assert.That(result is Result<Pokemon, PokemonApiError>.Success);
        Result<Pokemon, PokemonApiError>.Success success = (Result<Pokemon, PokemonApiError>.Success)result;
        Assert.That(success.data.Name, Is.EqualTo(name));
    }


    [Test]
    [DisplayName("포켓몬 잘못된 정보를 Repository에서 가지고 온다.")]
    public async Task Method_4()
    {
        //given
        string name = "dittooo";

        //when
        Result<Pokemon, PokemonApiError> result = await _repository.GetByNameAsync(name);

        //then
        Assert.IsNotNull(result);
        Assert.That(result is Result<Pokemon, PokemonApiError>.Error);
        Result<Pokemon, PokemonApiError>.Error error = (Result<Pokemon, PokemonApiError>.Error)result;
        Assert.That(error.data is PokemonApiError.NotFound);
    }


    [Test]
    [DisplayName("타임아웃 발생 NetworkTimeout Error 반환 ")]
    public async Task Method_5()
    {
        //given
        string name = "test";
        _dataSource = new BeTimeoutDataSource();
        _repository = new PokemonRepository(_dataSource);

        //when
        Result<Pokemon, PokemonApiError> result = await _repository.GetByNameAsync(name);

        //then
        Assert.IsNotNull(result);
        Assert.That(result is Result<Pokemon, PokemonApiError>.Error);
        Result<Pokemon, PokemonApiError>.Error error = (Result<Pokemon, PokemonApiError>.Error)result;
        Assert.That(error.data is PokemonApiError.NetworkTimeout);
    }

    [Test]
    [DisplayName("역직렬화 예외 발생 -> JsonSerialization Error 반환 ")]
    public async Task Method_6()
    {
        //given
        string name = "test";
        _dataSource = new BeJsonSerializationExceptionDataSource();
        _repository = new PokemonRepository(_dataSource);

        //when
        Result<Pokemon, PokemonApiError> result = await _repository.GetByNameAsync(name);

        //then
        Assert.IsNotNull(result);
        Assert.That(result is Result<Pokemon, PokemonApiError>.Error);
        Result<Pokemon, PokemonApiError>.Error error = (Result<Pokemon, PokemonApiError>.Error)result;
        Assert.That(error.data is PokemonApiError.JsonSerialization);
    }
}