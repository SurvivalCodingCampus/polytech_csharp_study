using Newtonsoft.Json;

namespace _250912;

public class PokemonSprites
{
    [JsonProperty("front_default")]
    public string? OfficialArtworkUrl { get; set; }
    
}