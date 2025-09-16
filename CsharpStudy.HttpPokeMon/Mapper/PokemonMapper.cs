using CsharpStudy.HttpPokeMon.DTO;
using CsharpStudy.HttpPokeMon.Models;

namespace CsharpStudy.HttpPokeMon.Mapper;

public static class PokemonMapper
{
    public static Pokemon ToPokemon(this PokemonDTO pokemonDto)
    {
        return new Pokemon(pokemonDto.Name ?? "", pokemonDto.OfficialArtworkUrl ?? "");
    }
}