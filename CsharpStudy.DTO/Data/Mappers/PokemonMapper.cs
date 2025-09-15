using CsharpStudy.DTO.Data.DataSources;
using CsharpStudy.DTO.Data.Models;

namespace CsharpStudy.DTO.Data.Mappers;

public static class PokemonMapper
{
    public static Pokemon ToPokemon(this PokemonDto dto)
    {
        List<string> stringifiedList = new List<string>();

        if (dto.Abilities.Count > 0)
        {
            foreach (var ability in dto.Abilities)
            {
                stringifiedList.Add(ability.Ability.Name);
            }
        }

        Pokemon pokemon = new Pokemon(
            name: dto.Name ?? "Missing",
            officialArtFront: dto.Sprites.Other.OfficialArtwork.FrontDefault ?? "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/1.png",
            abilities: stringifiedList
        );

        return pokemon;
    }
}