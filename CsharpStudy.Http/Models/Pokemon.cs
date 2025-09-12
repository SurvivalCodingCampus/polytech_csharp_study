using Newtonsoft.Json;

namespace CsharpStudy.Http.Models;

public class Pokemon
{
    [JsonProperty("name")] // 어트리뷰트 변경
    private string? Name { get; set; }

    [JsonProperty("sprites")] // 어트리뷰트 변경
    public OtherSprites? Sprites { get; set; }

    public Pokemon(string? name, OtherSprites? sprites)
    {
        Name = name;
        Sprites = sprites;
    }
}

public class OtherSprites
{
    [JsonProperty("official-artwork")] // 어트리뷰트 변경
    public PokemonSprites? OfficialArtwork { get; set; }
}

public class PokemonSprites
{
    [JsonProperty("front_default")] // 어트리뷰트 변경
    public string? OfficialArtworkUrl { get; set; }
}
    
    
