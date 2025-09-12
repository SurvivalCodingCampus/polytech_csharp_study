using Newtonsoft.Json;

namespace CsharpStudy.Http.Models;

public class Pokemon
{
    [JsonProperty("name")]
    public string? Name { get; set; }
    
    [JsonProperty("sprites")]
    public OtherSprites? Sprites { get; set; }
}