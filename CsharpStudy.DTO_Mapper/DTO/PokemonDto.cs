using Newtonsoft.Json;

namespace CsharpStudy.DTO_Mapper.DTO
{
    public class PokemonDto
    {
        [JsonProperty("abilities")]
        public List<AbilityDto>? Abilities { get; set; }

        [JsonProperty("base_experience")]
        public int? BaseExperience { get; set; }

        [JsonProperty("cries")]
        public CriesDto? Cries { get; set; }

        [JsonProperty("forms")]
        public List<FormDto>? Forms { get; set; }

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
        public List<MoveDto>? Moves { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("order")]
        public int? Order { get; set; }

        [JsonProperty("species")]
        public NamedResourceDto? Species { get; set; }

        [JsonProperty("sprites")]
        public SpritesDto? Sprites { get; set; }

        [JsonProperty("stats")]
        public List<StatDto>? Stats { get; set; }

        [JsonProperty("types")]
        public List<TypeDto>? Types { get; set; }

        [JsonProperty("weight")]
        public int? Weight { get; set; }
    }

    // --- Nested DTOs ---
    public class AbilityDto
    {
        [JsonProperty("ability")]
        public NamedResourceDto? Ability { get; set; }

        [JsonProperty("is_hidden")]
        public bool? IsHidden { get; set; }

        [JsonProperty("slot")]
        public int? Slot { get; set; }
    }

    public class CriesDto
    {
        [JsonProperty("latest")]
        public string? Latest { get; set; }

        [JsonProperty("legacy")]
        public string? Legacy { get; set; }
    }

    public class FormDto : NamedResourceDto { }

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
        public List<HeldItemVersionDto>? VersionDetails { get; set; }
    }

    public class HeldItemVersionDto
    {
        [JsonProperty("rarity")]
        public int? Rarity { get; set; }

        [JsonProperty("version")]
        public NamedResourceDto? Version { get; set; }
    }

    public class MoveDto
    {
        [JsonProperty("move")]
        public NamedResourceDto? Move { get; set; }

        [JsonProperty("version_group_details")]
        public List<MoveVersionDto>? VersionGroupDetails { get; set; }
    }

    public class MoveVersionDto
    {
        [JsonProperty("level_learned_at")]
        public int? LevelLearnedAt { get; set; }

        [JsonProperty("move_learn_method")]
        public NamedResourceDto? MoveLearnMethod { get; set; }

        [JsonProperty("version_group")]
        public NamedResourceDto? VersionGroup { get; set; }
    }

    public class SpritesDto
    {
        [JsonProperty("back_default")]
        public string? BackDefault { get; set; }

        [JsonProperty("back_shiny")]
        public string? BackShiny { get; set; }

        [JsonProperty("front_default")]
        public string? FrontDefault { get; set; }

        [JsonProperty("front_shiny")]
        public string? FrontShiny { get; set; }

        [JsonProperty("other")]
        public OtherSpritesDto? Other { get; set; }
    }

    public class OtherSpritesDto
    {
        [JsonProperty("official-artwork")]
        public OfficialArtworkDto? OfficialArtwork { get; set; }
    }

    public class OfficialArtworkDto
    {
        [JsonProperty("front_default")]
        public string? FrontDefault { get; set; }

        [JsonProperty("front_shiny")]
        public string? FrontShiny { get; set; }
    }

    public class StatDto
    {
        [JsonProperty("base_stat")]
        public int? BaseStat { get; set; }

        [JsonProperty("effort")]
        public int? Effort { get; set; }

        [JsonProperty("stat")]
        public NamedResourceDto? Stat { get; set; }
    }

    public class TypeDto
    {
        [JsonProperty("slot")]
        public int? Slot { get; set; }

        [JsonProperty("type")]
        public NamedResourceDto? Type { get; set; }
    }

    public class NamedResourceDto
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("url")]
        public string? Url { get; set; }
    }
}
