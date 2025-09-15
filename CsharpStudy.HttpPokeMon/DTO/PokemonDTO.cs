using System.Text.Json.Serialization;

namespace CsharpStudy.HttpPokeMon.DTO;

public class PokemonDTO
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("sprites")]
    public SpritesData? Sprites { get; set; }

    // 평탄화된 속성 - 실제 사용할 이미지 URL (고품질 우선, 없으면 기본 sprite)
    [JsonIgnore]
    public string? OfficialArtworkUrl => 
        Sprites?.Other?.OfficialArtwork?.FrontDefault ?? 
        Sprites?.FrontDefault;

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;

        var other = (PokemonDTO)obj;
        return string.Equals(Name, other.Name, StringComparison.Ordinal) &&
               string.Equals(OfficialArtworkUrl, other.OfficialArtworkUrl, StringComparison.Ordinal);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, OfficialArtworkUrl);
    }

    public override string ToString()
    {
        return $"PokemonDTO {{ Name = {Name ?? "null"}, OfficialArtworkUrl = {OfficialArtworkUrl ?? "null"} }}";
    }
}

// 별도 클래스로 분리
public class SpritesData
{
    [JsonPropertyName("front_default")]
    public string? FrontDefault { get; set; }

    [JsonPropertyName("other")]
    public OtherSprites? Other { get; set; }
}

public class OtherSprites
{
    [JsonPropertyName("official-artwork")]
    public OfficialArtworkData? OfficialArtwork { get; set; }
}

public class OfficialArtworkData
{
    [JsonPropertyName("front_default")]
    public string? FrontDefault { get; set; }
}