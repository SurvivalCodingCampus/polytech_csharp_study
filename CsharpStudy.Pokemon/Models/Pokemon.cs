using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CsharpStudy.Pokemon.Models;

public class Pokemon
{
    public string name { get; set; }
    public Sprites sprites { get; set; }
}

public class Sprites
{
    public Other other { get; set; }
}

public class Other
{
    [JsonProperty("official-artwork")] public OfficialArtwork OfficialArtwork { get; set; }
}

public class OfficialArtwork
{
    public string front_default { get; set; }
}