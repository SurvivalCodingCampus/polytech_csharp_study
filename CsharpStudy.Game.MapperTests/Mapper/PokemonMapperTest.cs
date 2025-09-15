using CsharpStudy.DTO.DTO;
using CsharpStudy.DTO.Mapper;
using NUnit.Framework;

namespace CsharpStudy.Game.MapperTests.Mapper;

[TestFixture]
[TestOf(typeof(PokemonMapper))]
public class PokemonMapperTest
{

    [Test]
    public void Mapper검증()
    {
        var dto = new PokemonDto
        {
            Name = "ditto",
            Sprites = new SpritesDto
            {
                Other = new OtherDto
                {
                    OfficialArtwork = new OfficialArtworkDto
                    {
                        FrontDefault =
                            "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/132.png"
                    }
                }
            }
        };
        
        var model = dto.ToModel();
        
        Assert.That(model.Name, Is.EqualTo("ditto"));
        Assert.That(model.ImageUrl, Is.EqualTo("https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/132.png"));
    }

    [Test]
    public void 이름이_null일_때_빈_문자열로_처리하는지_확인하는_테스트()
    {
        var dto = new PokemonDto
        {
            Name = null,
            Sprites = null
        };
        var model = dto.ToModel();
        Assert.That(model.Name, Is.EqualTo(""));
    }

    [Test]
    public void 이름이_이미_빈_문자열_일_때_그대로_반환하는지_테스트()
    {
        var dto = new PokemonDto
        {
            Name = "",
            Sprites = null
        };
        var model = dto.ToModel();
        Assert.That(model.Name, Is.EqualTo(""));
    }
}