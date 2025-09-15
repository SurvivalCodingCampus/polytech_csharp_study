using System.Text.Json.Serialization;

namespace CsharpStudy.HttpPokeMon.Models;

public class Pokemon
{
    [JsonPropertyName("name")]
    public string? Name {get; set;}
    
    // 상위 폴더
    [JsonPropertyName("sprites")]
    public OtherSprites? Sprites {get; set;}
}

public class OtherSprites
{
    [JsonPropertyName("official-artwork")]
    public PokemonSprites? OfficialArtwork {get; set;}
}

public class PokemonSprites
{
    [JsonPropertyName("front_default")]
    public string? OfficialArtworkUrl {get; set;}
}