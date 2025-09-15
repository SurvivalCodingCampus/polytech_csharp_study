using Newtonsoft.Json;

namespace CsharpStudy.DTO.DTO;

public class PokemonDto
{
        [JsonProperty("abilities")]
        public List<AbilitySlotDto>? Abilities { get; set; }

        [JsonProperty("base_experience")]
        public int? BaseExperience { get; set; }

        [JsonProperty("forms")]
        public List<NamedResourceDto>? Forms { get; set; }

        [JsonProperty("game_indices")]
        public List<GameIndexDto>? GameIndices { get; set; }

        [JsonProperty("height")]
        public int? Height { get; set; }

        [JsonProperty("held_items")]
        public List<HeldItemDto>? HeldItems { get; set; }

        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("is_default")]
        public bool? IsDefault { get; set; }

        [JsonProperty("location_area_encounters")]
        public string? LocationAreaEncounters { get; set; }

        [JsonProperty("moves")]
        public List<MoveSlotDto>? Moves { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("order")]
        public int? Order { get; set; }

        [JsonProperty("past_types")]
        public List<object>? PastTypes { get; set; }

        [JsonProperty("species")]
        public NamedResourceDto? Species { get; set; }

        [JsonProperty("sprites")]
        public SpritesDto? Sprites { get; set; }

        [JsonProperty("stats")]
        public List<StatSlotDto>? Stats { get; set; }

        [JsonProperty("types")]
        public List<TypeSlotDto>? Types { get; set; }

        [JsonProperty("weight")]
        public int? Weight { get; set; }
    }

    public class AbilitySlotDto
    {
        [JsonProperty("is_hidden")]
        public bool? IsHidden { get; set; }

        [JsonProperty("slot")]
        public int? Slot { get; set; }

        [JsonProperty("ability")]
        public NamedResourceDto? Ability { get; set; }
    }

    public class NamedResourceDto
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("url")]
        public string? Url { get; set; }
    }

    public class GameIndexDto
    {
        [JsonProperty("game_index")]
        public int? GameIndex { get; set; }

        [JsonProperty("version")]
        public NamedResourceDto? Version { get; set; }
    }

    public class HeldItemDto
    {
        [JsonProperty("item")]
        public NamedResourceDto? Item { get; set; }

        [JsonProperty("version_details")]
        public List<HeldItemVersionDetailDto>? VersionDetails { get; set; }
    }

    public class HeldItemVersionDetailDto
    {
        [JsonProperty("rarity")]
        public int? Rarity { get; set; }

        [JsonProperty("version")]
        public NamedResourceDto? Version { get; set; }
    }

    public class MoveSlotDto
    {
        [JsonProperty("move")]
        public NamedResourceDto? Move { get; set; }

        [JsonProperty("version_group_details")]
        public List<MoveVersionDetailDto>? VersionGroupDetails { get; set; }
    }

    public class MoveVersionDetailDto
    {
        [JsonProperty("level_learned_at")]
        public int? LevelLearnedAt { get; set; }

        [JsonProperty("version_group")]
        public NamedResourceDto? VersionGroup { get; set; }

        [JsonProperty("move_learn_method")]
        public NamedResourceDto? MoveLearnMethod { get; set; }
    }

    public class SpritesDto
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

        // "other" contains nested named maps (e.g. "official-artwork")
        [JsonProperty("other")]
        public Dictionary<string, object>? Other { get; set; }

        // "versions" contains a complex nested object keyed by generation/version.
        // If you need exact versioned sprite DTOs, we can expand this into typed classes.
        [JsonProperty("versions")]
        public Dictionary<string, object>? Versions { get; set; }
    }

    public class StatSlotDto
    {
        [JsonProperty("base_stat")]
        public int? BaseStat { get; set; }

        [JsonProperty("effort")]
        public int? Effort { get; set; }

        [JsonProperty("stat")]
        public NamedResourceDto? Stat { get; set; }
    }

    public class TypeSlotDto
    {
        [JsonProperty("slot")]
        public int? Slot { get; set; }

        [JsonProperty("type")]
        public NamedResourceDto? Type { get; set; }
    }
    