using Newtonsoft.Json;

namespace CsharpStudy.Http.Models;

public class Pokemon
{
    [JsonProperty("name")]
    public string? Name { get; set; }
    
    [JsonProperty("sprites")]
    public Sprites? Sprites { get; set; }
}

public class Sprites
{
    [JsonProperty("other")]
    public Other? Other { get; set; }
}

public class Other
{
    [JsonProperty("official-artwork")]
    public OfficialArtwork? OfficialArtwork { get; set; }
}

public class OfficialArtwork
{
    [JsonProperty("front_default")]
    public string? FrontDefault { get; set; }
}