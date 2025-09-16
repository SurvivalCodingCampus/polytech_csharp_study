using CsharpStudy.DTO_Mapper.DTO;
using CsharpStudy.DTO_Mapper.Models;

namespace CsharpStudy.DTO_Mapper.Mappers;

public static class PokemonMapper
{
    public static Pokemon ToModel(this PokemonDto dto)
    {
        return new Pokemon(
            name: dto.Name ?? "",
            url: dto.Sprites?.Other?.OfficialArtwork?.FrontDefault ?? ""
        );
    }
}