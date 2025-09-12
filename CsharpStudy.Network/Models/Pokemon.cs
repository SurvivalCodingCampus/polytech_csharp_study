using Newtonsoft.Json;

namespace CsharpStudy.Network.Models;

public class PokemonSprites
{
    [JsonProperty("front_default")]
    public string? OfficialArtWorkUrl {get; set;}
}

public class OtherSprites
{
    [JsonProperty("official-artwork")]
    public PokemonSprites? OfficialArtWork {get; set;}
}
public class Pokemon
{
    [JsonProperty("name")] public string? Name { get; set; }
    [JsonProperty("sprites")] public OtherSprites? Sprites { get; set; }
}