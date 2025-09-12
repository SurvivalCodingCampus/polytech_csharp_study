using Newtonsoft.Json;

namespace CsharpStudy.Http.Models;

public class PokemonSprites
{
    [JsonProperty("front_default")] public string OfiicialArtworkUrl { get; set; }
}

public class OtherSprites
{
    [JsonProperty("official-artwork")]
    public PokemonSprites OfiicialArtwork { get; set; }
}

public class Pokemon
{
    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("sprites")] public OtherSprites Sprites { get; set; }

}

