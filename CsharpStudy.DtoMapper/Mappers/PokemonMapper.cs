using CsharpStudy.DtoMapper.DTOs;

namespace CsharpStudy.DtoMapper.Mappers;

public static class PokemonMapper
{
    public static Models.Pokemon ToModel(this PokemonDto dto)
    {
        return new Models.Pokemon(
            Name: dto.Name ?? "", 
            ImageUrl: dto.Sprites?.Other?.OfficialArtwork?.FrontDefault ?? ""
        );
    }
}