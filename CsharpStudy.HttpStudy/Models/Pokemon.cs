using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CsharpStudy.HttpStudy.Data;

public class PokemonSprites
{
    [JsonProperty("front_default")]
    public string? OfficialArtworkUrl { get; set; }
}

public class OtherSprites
{
    [JsonProperty("official-artwort")]
    public PokemonSprites? OfficialArtwork { get; set; }
}

public class Pokemon
{
    [JsonProperty("name")]
    public string? Name { get; set; }

}