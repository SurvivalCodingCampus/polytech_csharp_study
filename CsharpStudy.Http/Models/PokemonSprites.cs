using Newtonsoft.Json;

namespace CsharpStudy.Http.Models;

// JSON의 "sprites" 객체에 해당
public class PokemonSprites
{
    [JsonProperty("front_default")] // 어트리뷰트 변경
    public string? OfficialArtworkUrl { get; set; }
}

public class OtherSprites
{
    [JsonProperty("official_artwork")]
    public PokemonSprites? OfficialArtwork { get; set; }
}

// JSON 최상위 객체에 해당
public class Pokemon
{
    [JsonProperty("name")]
    public string? Name { get; set; }
    
    [JsonProperty("sprites")]
    public OtherSprites? Sprites { get; set; }
}