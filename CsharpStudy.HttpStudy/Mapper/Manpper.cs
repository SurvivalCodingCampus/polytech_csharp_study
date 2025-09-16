using CsharpStudy.HttpStudy.Data;
using CsharpStudy.HttpStudy.DTO;

namespace CsharpStudy.HttpStudy.Mapper;

using CsharpStudy.HttpStudy.Mapper;

public static class Manpper
{
    public static Pokemon ToModel(PokemonDto dto)
    {
        return new Pokemon(
            name: dto.Name ?? "", 
            imageUrl: dto.Sprites?.Other?.OfficialArtwork?.FrontDefault ?? ""
        );
    }
}