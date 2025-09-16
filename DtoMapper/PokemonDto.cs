namespace DtoMapper;

using Newtonsoft.Json;
using System.Collections.Generic;

public class PokemonDto
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("base_experience")]
    public int BaseExperience { get; set; }

    [JsonProperty("height")]
    public int Height { get; set; }

    [JsonProperty("weight")]
    public int Weight { get; set; }

    [JsonProperty("abilities")]
    public List<PokemonAbilityDto> Abilities { get; set; }

    [JsonProperty("stats")]
    public List<PokemonStatDto> Stats { get; set; }

    [JsonProperty("types")]
    public List<PokemonTypeDto> Types { get; set; }

    [JsonProperty("moves")]
    public List<PokemonMoveDto> Moves { get; set; }
    
    [JsonProperty("sprites")]
    public SpritesDto Sprites { get; set; }
}

// sprites를 위한 DTO
public class SpritesDto
{
    [JsonProperty("other")]
    public OtherSpritesDto Other { get; set; }
}

// other를 위한 DTO
public class OtherSpritesDto
{
    [JsonProperty("official-artwork")]
    public OfficialArtworkDto OfficialArtwork { get; set; }
}

// official-artwork를 위한 DTO
public class OfficialArtworkDto
{
    [JsonProperty("front_default")]
    public string FrontDefault { get; set; }

    [JsonProperty("front_shiny")]
    public string FrontShiny { get; set; }
}

// 기존 하위 DTO들은 그대로 유지
public class PokemonAbilityDto
{
    [JsonProperty("ability")]
    public NamedApiResourceDto Ability { get; set; }
}

public class PokemonStatDto
{
    [JsonProperty("base_stat")]
    public int BaseStat { get; set; }

    [JsonProperty("stat")]
    public NamedApiResourceDto Stat { get; set; }
}

public class PokemonTypeDto
{
    [JsonProperty("slot")]
    public int Slot { get; set; }

    [JsonProperty("type")]
    public NamedApiResourceDto Type { get; set; }
}

public class PokemonMoveDto
{
    [JsonProperty("move")]
    public NamedApiResourceDto Move { get; set; }
}

public class NamedApiResourceDto
{
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("url")]
    public string Url { get; set; }
}