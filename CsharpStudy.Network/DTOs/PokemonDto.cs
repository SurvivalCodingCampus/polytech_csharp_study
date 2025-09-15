using Newtonsoft.Json;

namespace CsharpStudy.Network.DTOs;

// 스프라이트 이미지들을 담는 기본 클래스
public class PokemonSprites
{
    [JsonProperty("front_default")]
    public string? FrontDefault { get; set; }
    
    [JsonProperty("front_shiny")]
    public string? FrontShiny { get; set; }
    
    [JsonProperty("back_default")]
    public string? BackDefault { get; set; }
    
    [JsonProperty("back_shiny")]
    public string? BackShiny { get; set; }
}

// 공식 아트워크를 담는 클래스
public class OfficialArtwork
{
    [JsonProperty("front_default")]
    public string? FrontDefault { get; set; }
    
    [JsonProperty("front_shiny")]
    public string? FrontShiny { get; set; }
}

// other 하위의 스프라이트들
public class OtherSprites
{
    [JsonProperty("official-artwork")]
    public OfficialArtwork? OfficialArtwork { get; set; }
    
    [JsonProperty("home")]
    public PokemonSprites? Home { get; set; }
    
    [JsonProperty("showdown")]
    public PokemonSprites? Showdown { get; set; }
}

// 메인 스프라이트 클래스
public class Sprites
{
    [JsonProperty("front_default")]
    public string? FrontDefault { get; set; }
    
    [JsonProperty("front_shiny")]
    public string? FrontShiny { get; set; }
    
    [JsonProperty("back_default")]
    public string? BackDefault { get; set; }
    
    [JsonProperty("back_shiny")]
    public string? BackShiny { get; set; }
    
    [JsonProperty("other")]
    public OtherSprites? Other { get; set; }
}

// 포켓몬 능력
public class Ability
{
    [JsonProperty("name")]
    public string? Name { get; set; }
    
    [JsonProperty("url")]
    public string? Url { get; set; }
}

public class PokemonAbility
{
    [JsonProperty("ability")]
    public Ability? Ability { get; set; }
    
    [JsonProperty("is_hidden")]
    public bool IsHidden { get; set; }
    
    [JsonProperty("slot")]
    public int Slot { get; set; }
}

// 포켓몬 타입
public class Type
{
    [JsonProperty("name")]
    public string? Name { get; set; }
    
    [JsonProperty("url")]
    public string? Url { get; set; }
}

public class PokemonType
{
    [JsonProperty("type")]
    public Type? Type { get; set; }
    
    [JsonProperty("slot")]
    public int Slot { get; set; }
}

// 포켓몬 스탯
public class Stat
{
    [JsonProperty("name")]
    public string? Name { get; set; }
    
    [JsonProperty("url")]
    public string? Url { get; set; }
}

public class PokemonStat
{
    [JsonProperty("base_stat")]
    public int BaseStat { get; set; }
    
    [JsonProperty("effort")]
    public int Effort { get; set; }
    
    [JsonProperty("stat")]
    public Stat? Stat { get; set; }
}

// 메인 포켓몬 DTO 클래스
public class PokemonDto
{
    [JsonProperty("id")]
    public int Id { get; set; }
    
    [JsonProperty("name")]
    public string? Name { get; set; }
    
    [JsonProperty("height")]
    public int Height { get; set; }
    
    [JsonProperty("weight")]
    public int Weight { get; set; }
    
    [JsonProperty("base_experience")]
    public int BaseExperience { get; set; }
    
    [JsonProperty("is_default")]
    public bool IsDefault { get; set; }
    
    [JsonProperty("sprites")]
    public Sprites? Sprites { get; set; }
    
    [JsonProperty("abilities")]
    public List<PokemonAbility>? Abilities { get; set; }
    
    [JsonProperty("types")]
    public List<PokemonType>? Types { get; set; }
    
    [JsonProperty("stats")]
    public List<PokemonStat>? Stats { get; set; }
    
    // 편의 속성들
    public string? OfficialArtworkUrl => Sprites?.Other?.OfficialArtwork?.FrontDefault;
    public string? DefaultSpriteUrl => Sprites?.FrontDefault;
    public string? PrimaryType => Types?.FirstOrDefault()?.Type?.Name;
    public int? TotalStats => Stats?.Sum(s => s.BaseStat);
}