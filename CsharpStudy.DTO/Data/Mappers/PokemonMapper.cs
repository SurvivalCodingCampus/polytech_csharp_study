using CsharpStudy.DTO.Data.DataSources;
using CsharpStudy.DTO.Data.Models;

namespace CsharpStudy.DTO.Data.Mappers;

public static class PokemonMapper
{
    public static Pokemon ToPokemon(this PokemonDto dto)
    {
        List<string> stringifiedList = new List<string>();
        
        foreach (var ability in dto.Abilities)
        {
            stringifiedList.Add(ability.Ability.Name);
        }

        Pokemon pokemon = new Pokemon(
            name: dto.Name!,
            officialArtFront: dto.Sprites.Other.OfficialArtwork.FrontDefault!,
            abilities: stringifiedList!
        );
        
        return pokemon;
    }
}