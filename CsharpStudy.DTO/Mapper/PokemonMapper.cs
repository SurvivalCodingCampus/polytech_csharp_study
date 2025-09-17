using CsharpStudy.DTO.Common;
using CsharpStudy.DTO.DTOs;
using CsharpStudy.DTO.Model;
using CsharpStudy.DTO.Repositories;

namespace CsharpStudy.DTO.Mapper;

public static class PokemonMapper
{
    public static Model.Pokemon ToModel(this PokemonDto dto)
    {
        return new Model.Pokemon(
            Name: dto.Name ?? "",
            ImageUrl: dto.Sprites?.Other?.OfficialArtwork?.FrontDefault ?? ""
        );
    }
    
}