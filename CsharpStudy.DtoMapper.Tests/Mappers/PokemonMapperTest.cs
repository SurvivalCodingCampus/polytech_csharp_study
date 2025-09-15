//using CsharpStudy.DtoMapper.DTO;

using CsharpStudy.DtoMapper.Mappers;
using CsharpStudy.DtoMapper.Models;
using NUnit.Framework;

namespace CsharpStudy.DtoMapper.Tests.Mappers;

[TestFixture]
[TestOf(typeof(PokemonMapper))]
public class PokemonMapperTest
{
    // 시나리오 2: 이름(Name)이 Null인 경우
    [Test]
    public void ToModel_ShouldReturnEmptyName_WhenDtoNameIsNull()
    {
        // Given(주어진 DTO): name 속성이 null인 PokemonDto 객체 준비 
        // 여기서는 Name 속성이 null인 PokemonDto를 만들기 
        var givenDto = new PokemonDto
        {
            Name = null,
            Sprites = new SpritesDto() // 다른 속성도 테스트에 따라 설정 가능
        };

        // When(Mapper 실행): ToModel() 메서드 호출
        // 실제 테스트하려는 메서드를 호출합니다.
        var resultModel = givenDto.ToModel();

        // Then(기대 결과): Name 속성이 **빈 문자열("")**인 Pokemon 모델 객체가 반환된다. (프로그램 중단 없음)

        // 실행 결과가 우리가 기대하는 것과 같은지 확인합니다.
        // Assert 클래스의 여러 메서드를 사용합니다.

        Assert.That(resultModel.Name, Is.EqualTo(""));
        // > var name = dto.Name ?? ""; // dto.Name이 null이면, 기본값으로 빈 문자열("")을 사용한다.
    }
}