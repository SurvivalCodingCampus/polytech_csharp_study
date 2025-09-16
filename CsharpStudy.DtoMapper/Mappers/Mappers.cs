using CsharpStudy.DtoMapper.DTOs;
using CsharpStudy.DtoMapper.Models;

namespace CsharpStudy.DtoMapper.Mappers;

public static class Mappers
{
    public static Models.Pokemon ToModel(this PokemonDto dto)
    {
        if (dto == null)
        {
            return new Models.Pokemon(0, "", "", new List<AbilityWrapperDto>());
        }
        return new Models.Pokemon(
            id: dto.Id ?? 0,
            name: dto.Name ?? "", 
            imageUrl: dto.Sprites?.Other?.OfficialArtwork?.FrontDefault ?? "",
            abilities: dto.Abilities ?? new List<AbilityWrapperDto>()
        );
    }
}