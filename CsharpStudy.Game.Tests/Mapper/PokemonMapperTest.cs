using DtoMapper.Mapper;
using DtoMapper.Models;
using DtoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsharpStudy.Game.Tests.Mapper;

[TestClass]
public class PokemonMapperTest
{
    [TestMethod]
    public void ToModel_WhenTypesInDtoIsNull_ReturnsModelWithEmptyTypesList()
    {
        // 1. Arrange (테스트에 필요한 객체 준비)
        var dto = new PokemonDto
        {
            Name = "Bulbasaur",
            Types = null // 테스트 시나리오: Types가 null
        };

        // 2. Act (테스트 대상 메서드 실행)
        Pokemon model = dto.ToModel();

        // 3. Assert (결과 검증)
        Assert.IsNotNull(model); // 모델 객체가 null이 아닌지 확인
        Assert.AreEqual("Bulbasaur", model.Name); // 이름이 올바르게 매핑되었는지 확인
        Assert.IsNotNull(model.Types); // Types 리스트가 null이 아닌지 확인
        Assert.AreEqual(0, model.Types.Count); // Types 리스트가 비어 있는지 확인
    }
}