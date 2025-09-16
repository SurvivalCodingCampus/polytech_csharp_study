using CsharpStudy.Network.DTOs;
using CsharpStudy.Network.Models;

namespace CsharpStudy.Network.Mappers;

public class Mapper
{

    public static Pokemon ToModel(PokemonDto dto)
    {
        return new Pokemon(
            id: dto.Id,
            name: dto.Name ?? "",
            image: dto.DefaultSpriteUrl ?? ""
            );
    }
    
}