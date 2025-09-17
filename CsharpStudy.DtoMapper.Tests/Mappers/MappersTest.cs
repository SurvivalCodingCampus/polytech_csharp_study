using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CsharpStudy.DtoMapper.DataSources;
using CsharpStudy.DtoMapper.DTOs;
using CsharpStudy.DtoMapper.Mappers;
using CsharpStudy.DtoMapper.Models;
using CsharpStudy.DtoMapper.Repositories;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CsharpStudy.DtoMapper.Tests.Mappers;

[TestFixture]
[TestOf(typeof(DtoMapper.Mappers.Mappers))]
public class MappersTest
{

    [Test]
    public void ToModel_ReturnsCorrectPokemonModel()
    {
        var dto = new PokemonDto
        {
            Name = "Pikachu",
            Sprites = new SpritesDto
            {
                Other = new OtherSpritesDto
                {
                    OfficialArtwork = new OfficialArtworkDto
                    {
                        FrontDefault = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/25.png"
                    }
                }
            },
            Abilities = new List<AbilityWrapperDto>
            {
                new AbilityWrapperDto
                {
                    Ability = new NamedApiResourceDto { Name = "Static" } 
                    
                } 
            }
        };
        var resultModel = dto.ToModel();
        
        Assert.That(resultModel, Is.Not.Null);
        Assert.That(resultModel.Name, Is.EqualTo("Pikachu"));
        Assert.That(resultModel.ImageUrl, Is.EqualTo("https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/25.png"), resultModel.ImageUrl);
        Assert.That(resultModel.Abilities.Count, Is.EqualTo(1));
    }

    [Test]
    public void ToModel_ReturnsModelWithDefaultValues() // 유효하지 않은 데이터 기본값으로 표시
    {
        var dto = new PokemonDto
        {
            Name = "",
            Sprites = new SpritesDto
            {
                Other = new OtherSpritesDto
                {
                    OfficialArtwork = new OfficialArtworkDto
                        {
                            FrontDefault = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/25.png"
                        }
                 }
             },
            Abilities = new List<AbilityWrapperDto>
            {
                new AbilityWrapperDto
                {
                    Ability = new NamedApiResourceDto { Name = "Static" } 
                } 
            }
        };
        
        var model = dto.ToModel();
        
        Assert.That(model, Is.Not.Null);
        Assert.That("", Is.EqualTo(model.Name));
    }
    
    private MockPokemon _mockDataSource = new MockPokemon();
    [Test]
    public async Task ToModel_WithPikachuData_ReturnsCorrectPokemonModel()
    {
        // Arrange (준비)
        var dtoResponse = await _mockDataSource.GetPokemonAsync("Pikachu");
        var dto = dtoResponse.Body;

        // Act (실행)
        // 매퍼를 사용하여 DTO를 모델로 변환합니다.
        var model = dto.ToModel();

        // Assert (단언)
        Assert.That(model, Is.Not.Null);
        Assert.That(model.Name, Is.EqualTo("Pikachu"));
        Assert.That(model.Id, Is.EqualTo(25));
    }
    
    [Test]
    public async Task GetPokemonAsync_ReturnsNullResponse()
    {
        // Arrange
        string pokemonName = "  ";

        // Act
        var response = await _mockDataSource.GetPokemonAsync(pokemonName);

        // Assert
        Assert.That(response, Is.Not.Null);
        Assert.That(response.Body, Is.Null);
        Assert.That(response.StatusCode, Is.EqualTo(404));
    }
    
    public class MockTimeoutDataSource : IPokemonApiDataSource
    { 
        public async Task<Response<PokemonDto>> GetPokemonAsync(string pokemonName)
        {
            throw new TimeoutException("JSON 역직렬화 오류 발생");
        }
    }
    
    [Test]
    public async Task ShouldReturnTimeoutError()
    {
        // Arrange
        var mockDataSource = new MockTimeoutDataSource();
        var repository = new PokemonRepository(mockDataSource); // 레포지토리 클래스명을 가정함

        // Act
        var result = await repository.GetPokemonByNameAsync("dittooo");

        // Assert
        // 패턴 매칭을 사용하여 result가 Error 레코드인지 확인하고
        // errorResult 변수에 바인딩합니다.
        if (result is Result<Pokemon, PokemonError>.Error errorResult)
        {
            // 'error' 속성에 접근하여 PokemonError.Timeout과 비교합니다.
            Assert.That(errorResult.error, Is.EqualTo(PokemonError.Timeout));
        }
        else
        {
            // 예상치 못한 결과가 나오면 테스트를 실패시킵니다.
            Assert.Fail("The result was not an error as expected.");
        }
    }

    public class MockSerializationExceptionDataSource : IPokemonApiDataSource
    {
        public async Task<Response<PokemonDto>> GetPokemonAsync(string pokemonName)
        {
            throw new JsonSerializationException("JSON 역직렬화 오류 발생");
        }
    }

    [Test]
    public async Task ShouldReturnSerializationException()
    {
        // Arrange
        var mockDataSource = new MockSerializationExceptionDataSource();
        var repository = new PokemonRepository(mockDataSource); 

        // Act
        var result = await repository.GetPokemonByNameAsync("ditto");

        // Assert
        // 패턴 매칭으로 결과가 Error 타입인지 확인하고, 에러 값이 PokemonError.Timeout과 일치하는지 검증합니다.
        if (result is Result<Pokemon, PokemonError>.Error errorResult)
        {
            Assert.That(errorResult.error, Is.EqualTo(PokemonError.Timeout));
        }
        else
        {
            Assert.Fail("예상치 못한 결과가 반환되었습니다. Timeout 에러여야 합니다.");
        }
    }


}