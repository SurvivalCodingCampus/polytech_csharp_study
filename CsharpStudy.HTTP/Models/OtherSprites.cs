using Newtonsoft.Json;

namespace CsharpStudy.Http.Models;

public class OtherSprites
{
    [JsonProperty("official-artwork")]
    public PokemonSprites? OfficialArtwork { get; set; }
}