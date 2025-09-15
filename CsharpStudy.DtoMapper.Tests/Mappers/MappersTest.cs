using System.Collections.Generic;
using CsharpStudy.DtoMapper.DTOs;
using CsharpStudy.DtoMapper.Mappers;
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
    
}