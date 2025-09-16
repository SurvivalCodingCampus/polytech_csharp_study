using Newtonsoft.Json;
using System.Collections.Generic;

public class PokemonDto
{
    [JsonProperty("id")]
    public int? Id { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("base_experience")]
    public int? BaseExperience { get; set; }

    [JsonProperty("height")]
    public int? Height { get; set; }

    [JsonProperty("is_default")]
    public bool? IsDefault { get; set; }

    [JsonProperty("order")]
    public int? Order { get; set; }

    [JsonProperty("weight")]
    public int? Weight { get; set; }

    [JsonProperty("abilities")]
    public List<PokemonAbilityDto>? Abilities { get; set; }

    [JsonProperty("forms")]
    public List<NamedApiResourceDto>? Forms { get; set; }

    [JsonProperty("game_indices")]
    public List<VersionGameIndexDto>? GameIndices { get; set; }

    [JsonProperty("held_items")]
    public List<PokemonHeldItemDto>? HeldItems { get; set; }

    [JsonProperty("location_area_encounters")]
    public string? LocationAreaEncounters { get; set; }

    [JsonProperty("moves")]
    public List<PokemonMoveDto>? Moves { get; set; }

    [JsonProperty("past_abilities")]
    public List<PastAbilityDto>? PastAbilities { get; set; }

    [JsonProperty("sprites")]
    public PokemonSpritesDto? Sprites { get; set; }

    [JsonProperty("species")]
    public NamedApiResourceDto? Species { get; set; }

    [JsonProperty("stats")]
    public List<PokemonStatDto>? Stats { get; set; }

    [JsonProperty("types")]
    public List<PokemonTypeDto>? Types { get; set; }

    [JsonProperty("past_types")]
    public List<PastTypeDto>? PastTypes { get; set; }
}

public class PokemonAbilityDto
{
    [JsonProperty("is_hidden")]
    public bool? IsHidden { get; set; }

    [JsonProperty("slot")]
    public int? Slot { get; set; }

    [JsonProperty("ability")]
    public NamedApiResourceDto? Ability { get; set; }
}

public class VersionGameIndexDto
{
    [JsonProperty("game_index")]
    public int? GameIndex { get; set; }

    [JsonProperty("version")]
    public NamedApiResourceDto? Version { get; set; }
}

public class PokemonHeldItemDto
{
    [JsonProperty("item")]
    public NamedApiResourceDto? Item { get; set; }

    [JsonProperty("version_details")]
    public List<PokemonHeldItemVersionDto>? VersionDetails { get; set; }
}

public class PokemonHeldItemVersionDto
{
    [JsonProperty("rarity")]
    public int? Rarity { get; set; }

    [JsonProperty("version")]
    public NamedApiResourceDto? Version { get; set; }
}

public class PokemonMoveDto
{
    [JsonProperty("move")]
    public NamedApiResourceDto? Move { get; set; }

    [JsonProperty("version_group_details")]
    public List<PokemonMoveVersionDto>? VersionGroupDetails { get; set; }
}

public class PokemonMoveVersionDto
{
    [JsonProperty("level_learned_at")]
    public int? LevelLearnedAt { get; set; }

    [JsonProperty("move_learn_method")]
    public NamedApiResourceDto? MoveLearnMethod { get; set; }

    [JsonProperty("version_group")]
    public NamedApiResourceDto? VersionGroup { get; set; }
}

public class PokemonSpritesDto
{
    [JsonProperty("back_default")]
    public string? BackDefault { get; set; }

    [JsonProperty("back_female")]
    public string? BackFemale { get; set; }

    [JsonProperty("back_shiny")]
    public string? BackShiny { get; set; }

    [JsonProperty("back_shiny_female")]
    public string? BackShinyFemale { get; set; }

    [JsonProperty("front_default")]
    public string? FrontDefault { get; set; }

    [JsonProperty("front_female")]
    public string? FrontFemale { get; set; }

    [JsonProperty("front_shiny")]
    public string? FrontShiny { get; set; }

    [JsonProperty("front_shiny_female")]
    public string? FrontShinyFemale { get; set; }

    [JsonProperty("other")]
    public OtherSpritesDto? Other { get; set; }

    [JsonProperty("versions")]
    public Dictionary<string, GenerationSpritesDto>? Versions { get; set; }
}

public class OtherSpritesDto
{
    [JsonProperty("dream_world")]
    public DreamWorldSpritesDto? DreamWorld { get; set; }

    [JsonProperty("home")]
    public HomeSpritesDto? Home { get; set; }

    [JsonProperty("official-artwork")]
    public OfficialArtworkSpritesDto? OfficialArtwork { get; set; }
}

public class DreamWorldSpritesDto
{
    [JsonProperty("front_default")]
    public string? FrontDefault { get; set; }

    [JsonProperty("front_female")]
    public string? FrontFemale { get; set; }
}

public class HomeSpritesDto
{
    [JsonProperty("front_default")]
    public string? FrontDefault { get; set; }

    [JsonProperty("front_female")]
    public string? FrontFemale { get; set; }

    [JsonProperty("front_shiny")]
    public string? FrontShiny { get; set; }

    [JsonProperty("front_shiny_female")]
    public string? FrontShinyFemale { get; set; }
}

public class OfficialArtworkSpritesDto
{
    [JsonProperty("front_default")]
    public string? FrontDefault { get; set; }

    [JsonProperty("front_shiny")]
    public string? FrontShiny { get; set; }
}

public class GenerationSpritesDto
{
    [JsonProperty("red-blue")]
    public RedBlueSpritesDto? RedBlue { get; set; }

    [JsonProperty("yellow")]
    public YellowSpritesDto? Yellow { get; set; }

    [JsonProperty("gold")]
    public GoldSpritesDto? Gold { get; set; }
    
    // 이 외에 다른 세대들도 이와 같이 추가 가능
}

public class RedBlueSpritesDto
{
    [JsonProperty("back_default")]
    public string? BackDefault { get; set; }

    [JsonProperty("back_gray")]
    public string? BackGray { get; set; }

    [JsonProperty("front_default")]
    public string? FrontDefault { get; set; }

    [JsonProperty("front_gray")]
    public string? FrontGray { get; set; }
}

public class YellowSpritesDto
{
    [JsonProperty("back_default")]
    public string? BackDefault { get; set; }

    [JsonProperty("back_gray")]
    public string? BackGray { get; set; }

    [JsonProperty("front_default")]
    public string? FrontDefault { get; set; }

    [JsonProperty("front_gray")]
    public string? FrontGray { get; set; }
}

public class GoldSpritesDto
{
    [JsonProperty("back_default")]
    public string? BackDefault { get; set; }

    [JsonProperty("front_default")]
    public string? FrontDefault { get; set; }

    [JsonProperty("front_shiny")]
    public string? FrontShiny { get; set; }
    
}

public class PokemonStatDto
{
    [JsonProperty("base_stat")]
    public int? BaseStat { get; set; }

    [JsonProperty("effort")]
    public int? Effort { get; set; }

    [JsonProperty("stat")]
    public NamedApiResourceDto? Stat { get; set; }
}

public class PokemonTypeDto
{
    [JsonProperty("slot")]
    public int? Slot { get; set; }

    [JsonProperty("type")]
    public NamedApiResourceDto? Type { get; set; }
}

public class PastAbilityDto
{
    [JsonProperty("abilities")]
    public List<PokemonAbilityDto>? Abilities { get; set; }

    [JsonProperty("generation")]
    public NamedApiResourceDto? Generation { get; set; }
}

public class PastTypeDto
{
    [JsonProperty("generation")]
    public NamedApiResourceDto? Generation { get; set; }

    [JsonProperty("types")]
    public List<PokemonTypeDto>? Types { get; set; }
}

// Common-usage DTO
public class NamedApiResourceDto
{
    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("url")]
    public string? Url { get; set; }
}