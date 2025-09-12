using System.Text.Json.Serialization;

namespace Csharp_study.http.Model;

public class PokemonSprites
{
    [JsonPropertyName("front_default")]
    public string? OfficialArtworkUrl { get; set; }

   
}

public class OtherSprites
{
   [JsonPropertyName("official-artwork")]
   public PokemonSprites? OfficialArtwork { get; set; }


}
public class Pokemon
{
    static async Task Main(string[] args)
    {
        
    }
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    
    [JsonPropertyName("sprites")]
    public OtherSprites? Sprites { get; set; }

    
}




