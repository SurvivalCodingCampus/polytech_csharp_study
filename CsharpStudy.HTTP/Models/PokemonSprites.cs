using Newtonsoft.Json;

namespace CsharpStudy.Http.Models;

public class PokemonSprites
{
    [JsonProperty("front_default")]
    public string? OfficialArtworkUrl { get; set; }
}