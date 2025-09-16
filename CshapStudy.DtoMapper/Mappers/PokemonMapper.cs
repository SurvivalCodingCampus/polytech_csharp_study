using CshapStudy.DtoMapper.DTOs;

namespace CshapStudy.DtoMapper.Mappers;

public static class PokemonMapper
{
    public static Models.Pokemon ToModel(this PokemonDto dto)
    {
        return new Models.Pokemon(
            name: dto.Name ?? "",
            imageUrl: dto.Sprites?.Other?.OfficialArtwork?.FrontDefault ?? ""
        );
    }
}