using Newtonsoft.Json;

namespace CsharpStudy.Http.Models;

public class PokemonSprites
{
    [JsonProperty("front_default")] // 어트리뷰트 변경
    public string? OfficialArtworkUrl { get; set; }
}

public class OtherSprites
{
    [JsonProperty("official-artwork")]
    public PokemonSprites? OfficialArtwork { get; set; }
}
public class Pokemon
{
    [JsonProperty("name")] 
    public string? Name { get; set; }
    
    [JsonProperty("sprites")]
    public OtherSprites? Sprites { get; set; }
}