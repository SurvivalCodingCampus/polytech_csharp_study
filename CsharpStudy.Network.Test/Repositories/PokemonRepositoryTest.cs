using System;
using System.ComponentModel;
using System.Threading.Tasks;
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
    private IRepository<Result<Pokemon, Error>> _repository;

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

        var pokemon = Mapper.ToModel(pokemonDto);

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
        string name = "pikachu";

        Result<Pokemon, Error> result = await _repository.GetByNameAsync(name);

        ValidateError(result);

        Assert.IsNotNull(result);
        Assert.That(result is Result<Pokemon, Error>.Success);
        Result<Pokemon, Error>.Success success = (Result<Pokemon, Error>.Success)result;
        Assert.That(success.data.Name, Is.EqualTo(name));
    }
    
    
    [Test]
    [DisplayName("포켓몬 잘못된 정보를 Repository에서 가지고 온다.")]
    public async Task Method_4()
    {
        string name = "dittooo";

        Result<Pokemon, Error> result = await _repository.GetByNameAsync(name);
        
        Assert.IsNotNull(result);
        Assert.That(result is Result<Pokemon, Error>.Error);
        Result<Pokemon, Error>.Error error = (Result<Pokemon, Error>.Error)result;
        Assert.That(error.data is Error.NotFound);
    }

    private static void ValidateError(Result<Pokemon, Error> result)
    {
        switch (result)
        {
            case Result<Pokemon, Error>.Success success:
                Console.WriteLine($"포켓몬 이름 : {success.data.Name}");
                Console.WriteLine($"이미지 URI : {success.data.Image}");
                break;
            case Result<Pokemon, Error>.Error error:
                switch (error.data)
                {
                    case Error.NotFound:
                        Console.WriteLine("오류: 찾을 수 없습니다.");
                        break;
                    case Error.NetworkTimeout:
                        Console.WriteLine("오류: 네트워크 연결 초과.");
                        break;
                    case Error.AuthenticationFailed:
                        Console.WriteLine("오류: 권한이 없습니다.");
                        break;
                    default:
                        Console.WriteLine("오류: 알 수 없는 오류가 발생했습니다.");
                        break;
                }

                break;
        }
    }
}