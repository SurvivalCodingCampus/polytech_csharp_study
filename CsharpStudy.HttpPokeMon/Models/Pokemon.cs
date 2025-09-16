using System.Text.Json.Serialization;

namespace CsharpStudy.HttpPokeMon.Models;

public class Pokemon
{
    public Pokemon(string? name, string? imageUrl)
    {
        Name = name;
        ImageUrl = imageUrl;
    }

    public string? Name {get; set;}
    
    public string? ImageUrl {get; set;}
}

// public class OtherSprites
// {
//     [JsonPropertyName("official-artwork")]
//     public PokemonSprites? OfficialArtwork {get; set;}
// }
//
// public class PokemonSprites
// {
//     [JsonPropertyName("front_default")]
//     public string? OfficialArtworkUrl {get; set;}
// }
