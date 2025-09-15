using System.Collections.Generic;
using Newtonsoft.Json;

#nullable enable

public sealed class PokemonDto
{
    [JsonProperty("id")]                 public int? Id { get; set; }
    [JsonProperty("name")]               public string? Name { get; set; }
    [JsonProperty("base_experience")]    public int? BaseExperience { get; set; }
    [JsonProperty("height")]             public int? Height { get; set; }
    [JsonProperty("is_default")]         public bool? IsDefault { get; set; }
    [JsonProperty("order")]              public int? Order { get; set; }
    [JsonProperty("weight")]             public int? Weight { get; set; }

    [JsonProperty("abilities")]          public List<PokemonAbilityDto>? Abilities { get; set; }
    [JsonProperty("forms")]              public List<NamedApiResourceDto>? Forms { get; set; }
    [JsonProperty("game_indices")]       public List<VersionGameIndexDto>? GameIndices { get; set; }
    [JsonProperty("held_items")]         public List<PokemonHeldItemDto>? HeldItems { get; set; }
    [JsonProperty("location_area_encounters")]
                                         public string? LocationAreaEncounters { get; set; }
    [JsonProperty("moves")]              public List<PokemonMoveDto>? Moves { get; set; }
    [JsonProperty("species")]            public NamedApiResourceDto? Species { get; set; }
    [JsonProperty("sprites")]            public PokemonSpritesDto? Sprites { get; set; }
    [JsonProperty("stats")]              public List<PokemonStatDto>? Stats { get; set; }
    [JsonProperty("types")]              public List<PokemonTypeSlotDto>? Types { get; set; }

    // Newer field (present in v2 data)
    [JsonProperty("past_types")]         public List<PokemonPastTypeDto>? PastTypes { get; set; }

    // Newer field on some Pokémon (audio URLs)
    [JsonProperty("cries")]              public PokemonCriesDto? Cries { get; set; }
}

public sealed class PokemonAbilityDto
{
    [JsonProperty("is_hidden")] public bool? IsHidden { get; set; }
    [JsonProperty("slot")]      public int? Slot { get; set; }
    [JsonProperty("ability")]   public NamedApiResourceDto? Ability { get; set; }
}

public sealed class VersionGameIndexDto
{
    [JsonProperty("game_index")] public int? GameIndex { get; set; }
    [JsonProperty("version")]    public NamedApiResourceDto? Version { get; set; }
}

public sealed class PokemonHeldItemDto
{
    [JsonProperty("item")]            public NamedApiResourceDto? Item { get; set; }
    [JsonProperty("version_details")] public List<PokemonHeldItemVersionDto>? VersionDetails { get; set; }
}

public sealed class PokemonHeldItemVersionDto
{
    [JsonProperty("rarity")]  public int? Rarity { get; set; }
    [JsonProperty("version")] public NamedApiResourceDto? Version { get; set; }
}

public sealed class PokemonMoveDto
{
    [JsonProperty("move")]                    public NamedApiResourceDto? Move { get; set; }
    [JsonProperty("version_group_details")]   public List<PokemonMoveVersionDto>? VersionGroupDetails { get; set; }
}

public sealed class PokemonMoveVersionDto
{
    [JsonProperty("level_learned_at")]   public int? LevelLearnedAt { get; set; }
    [JsonProperty("move_learn_method")]  public NamedApiResourceDto? MoveLearnMethod { get; set; }
    [JsonProperty("version_group")]      public NamedApiResourceDto? VersionGroup { get; set; }
}

public sealed class PokemonStatDto
{
    [JsonProperty("base_stat")] public int? BaseStat { get; set; }
    [JsonProperty("effort")]    public int? Effort { get; set; }
    [JsonProperty("stat")]      public NamedApiResourceDto? Stat { get; set; }
}

public sealed class PokemonTypeSlotDto
{
    [JsonProperty("slot")] public int? Slot { get; set; }
    [JsonProperty("type")] public NamedApiResourceDto? Type { get; set; }
}

public sealed class PokemonPastTypeDto
{
    [JsonProperty("generation")] public NamedApiResourceDto? Generation { get; set; }
    [JsonProperty("types")]      public List<PokemonTypeSlotDto>? Types { get; set; }
}

public sealed class PokemonCriesDto
{
    [JsonProperty("latest")] public string? Latest { get; set; }
    [JsonProperty("legacy")] public string? Legacy { get; set; }
}

public sealed class PokemonSpritesDto
{
    // Common sprite fields
    [JsonProperty("back_default")]        public string? BackDefault { get; set; }
    [JsonProperty("back_female")]         public string? BackFemale { get; set; }
    [JsonProperty("back_shiny")]          public string? BackShiny { get; set; }
    [JsonProperty("back_shiny_female")]   public string? BackShinyFemale { get; set; }
    [JsonProperty("front_default")]       public string? FrontDefault { get; set; }
    [JsonProperty("front_female")]        public string? FrontFemale { get; set; }
    [JsonProperty("front_shiny")]         public string? FrontShiny { get; set; }
    [JsonProperty("front_shiny_female")]  public string? FrontShinyFemale { get; set; }

    // Frequently used nested groups
    [JsonProperty("other")]    public PokemonOtherSpritesDto? Other { get; set; }

    // The full "versions" tree is very deep; map as a dictionary to keep it flexible.
    [JsonProperty("versions")] public Dictionary<string, object?>? Versions { get; set; }
}

public sealed class PokemonOtherSpritesDto
{
    [JsonProperty("dream_world")]      public PokemonSimpleSpriteSetDto? DreamWorld { get; set; }
    [JsonProperty("home")]             public PokemonHomeSpriteSetDto? Home { get; set; }
    [JsonProperty("official-artwork")] public PokemonOfficialArtworkDto? OfficialArtwork { get; set; }
    // Some datasets also include "showdown"
    [JsonProperty("showdown")]         public PokemonSimpleSpriteSetDto? Showdown { get; set; }
}

public sealed class PokemonSimpleSpriteSetDto
{
    [JsonProperty("front_default")]      public string? FrontDefault { get; set; }
    [JsonProperty("front_female")]       public string? FrontFemale { get; set; }
    [JsonProperty("front_shiny")]        public string? FrontShiny { get; set; }
    [JsonProperty("front_shiny_female")] public string? FrontShinyFemale { get; set; }
    [JsonProperty("back_default")]       public string? BackDefault { get; set; }
    [JsonProperty("back_shiny")]         public string? BackShiny { get; set; }
    [JsonProperty("back_female")]        public string? BackFemale { get; set; }
    [JsonProperty("back_shiny_female")]  public string? BackShinyFemale { get; set; }
}

public sealed class PokemonHomeSpriteSetDto
{
    [JsonProperty("front_default")]      public string? FrontDefault { get; set; }
    [JsonProperty("front_female")]       public string? FrontFemale { get; set; }
    [JsonProperty("front_shiny")]        public string? FrontShiny { get; set; }
    [JsonProperty("front_shiny_female")] public string? FrontShinyFemale { get; set; }
}

public sealed class PokemonOfficialArtworkDto
{
    [JsonProperty("front_default")] public string? FrontDefault { get; set; }
    [JsonProperty("front_shiny")]   public string? FrontShiny { get; set; }
}

public sealed class NamedApiResourceDto
{
    [JsonProperty("name")] public string? Name { get; set; }
    [JsonProperty("url")]  public string? Url { get; set; }
}
