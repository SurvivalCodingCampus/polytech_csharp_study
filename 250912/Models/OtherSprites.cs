using Newtonsoft.Json;

namespace _250912;

public class OtherSprites
{
    [JsonProperty("official_artwork")]
    public PokemonSprites? OfficialArtwork { get; set; }
}