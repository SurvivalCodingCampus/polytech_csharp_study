using Newtonsoft.Json;

namespace Pokemon;

public class Pokemon
{
    [JsonProperty("name")]
    public string? Name {get; set;}

    [JsonProperty("sprites")]
    public Sprites? Sprites {get; set;}
    
}

public class Sprites
{
    public Other other { get; set; }
}

public class Other
{
    [JsonProperty("official-artwork")] public OfficialArtwork OfficialArtwork {get; set;}
}

public class OfficialArtwork
{
    public string front_default {get; set;}
}

/*public class PokemonSprites
{
    [JsonProperty("front_default")]
    public string? OfficialArtworkUrl {get; set;}
}

public class OtherSprites
{
    [JsonProperty("official-artwork")]
    public PokemonSprites? OfficialArtwork {get; set;}
}

public class Pokemon
{
}*/