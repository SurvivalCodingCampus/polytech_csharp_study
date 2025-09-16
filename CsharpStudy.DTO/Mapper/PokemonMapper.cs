using CsharpStudy.DTO.DTOs;
using CsharpStudy.DTO.Model;

namespace CsharpStudy.DTO.Mapper;

public static class PokemonMapper
{
    public static Model.Pokemon ToModel(this PokemonDto dto)
    {
        return new Model.Pokemon(
            name: dto.Name ?? "",
            imageUrl: dto.Sprites?.Other?.OfficialArtwork?.FrontDefault ?? ""
        );
    }
    
}