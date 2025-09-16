using Newtonsoft.Json;

namespace CshapStudy.DtoMapper.DTOs
{
    public class PokemonDto
    {
        [JsonProperty("abilities")]
        public List<AbilitySlotDto>? Abilities { get; set; }

        [JsonProperty("base_experience")]
        public int? BaseExperience { get; set; }

        [JsonProperty("cries")]
        public CriesDto? Cries { get; set; }

        [JsonProperty("forms")]
        public List<NamedApiResourceDto>? Forms { get; set; }

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

        [JsonProperty("past_abilities")]
        public List<PastAbilityDto>? PastAbilities { get; set; }

        [JsonProperty("past_types")]
        public List<object>? PastTypes { get; set; }

        [JsonProperty("species")]
        public NamedApiResourceDto? Species { get; set; }

        [JsonProperty("sprites")]
        public SpritesDto? Sprites { get; set; }

        [JsonProperty("stats")]
        public List<StatDto>? Stats { get; set; }

        [JsonProperty("types")]
        public List<TypeDto>? Types { get; set; }

        [JsonProperty("weight")]
        public int? Weight { get; set; }
    }
    
    // --- 중첩된 DTO 클래스들 ---

    public class AbilitySlotDto
    {
        [JsonProperty("ability")]
        public NamedApiResourceDto? Ability { get; set; }

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

    public class GameIndexDto
    {
        [JsonProperty("game_index")]
        public int? GameIndex { get; set; }

        [JsonProperty("version")]
        public NamedApiResourceDto? Version { get; set; }
    }

    public class HeldItemDto
    {
        [JsonProperty("item")]
        public NamedApiResourceDto? Item { get; set; }

        [JsonProperty("version_details")]
        public List<VersionDetailDto>? VersionDetails { get; set; }
    }

    public class VersionDetailDto
    {
        [JsonProperty("rarity")]
        public int? Rarity { get; set; }

        [JsonProperty("version")]
        public NamedApiResourceDto? Version { get; set; }
    }

    public class MoveDto
    {
        [JsonProperty("move")]
        public NamedApiResourceDto? Move { get; set; }

        [JsonProperty("version_group_details")]
        public List<MoveLearnMethodDto>? VersionGroupDetails { get; set; }
    }

    public class MoveLearnMethodDto
    {
        [JsonProperty("level_learned_at")]
        public int? LevelLearnedAt { get; set; }

        [JsonProperty("move_learn_method")]
        public NamedApiResourceDto? MoveLearnMethod { get; set; }

        [JsonProperty("version_group")]
        public NamedApiResourceDto? VersionGroup { get; set; }
    }

    public class PastAbilityDto
    {
        [JsonProperty("abilities")]
        public List<AbilitySlotDto>? Abilities { get; set; }

        [JsonProperty("generation")]
        public NamedApiResourceDto? Generation { get; set; }
    }

    public class SpritesDto
    {
        [JsonProperty("back_default")]
        public string? BackDefault { get; set; }

        [JsonProperty("back_female")]
        public string? BackFemale { get; set; } // Nullable string

        [JsonProperty("back_shiny")]
        public string? BackShiny { get; set; }

        [JsonProperty("back_shiny_female")]
        public string? BackShinyFemale { get; set; } // Nullable string

        [JsonProperty("front_default")]
        public string? FrontDefault { get; set; }

        [JsonProperty("front_female")]
        public string? FrontFemale { get; set; } // Nullable string

        [JsonProperty("front_shiny")]
        public string? FrontShiny { get; set; }

        [JsonProperty("front_shiny_female")]
        public string? FrontShinyFemale { get; set; } // Nullable string

        [JsonProperty("other")]
        public OtherSpritesDto? Other { get; set; }

        [JsonProperty("versions")]
        public Dictionary<string, object>? Versions { get; set; }
    }

    public class OtherSpritesDto
    {
        [JsonProperty("dream_world")]
        public DreamWorldDto? DreamWorld { get; set; }

        [JsonProperty("home")]
        public HomeDto? Home { get; set; }

        [JsonProperty("official-artwork")]
        public OfficialArtworkDto? OfficialArtwork { get; set; }
        
        [JsonProperty("showdown")]
        public ShowdownDto? Showdown { get; set; }
    }
    
    public class DreamWorldDto
    {
        [JsonProperty("front_default")]
        public string? FrontDefault { get; set; }
        
        [JsonProperty("front_female")]
        public string? FrontFemale { get; set; }
    }
    
    public class HomeDto
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

    public class OfficialArtworkDto
    {
        [JsonProperty("front_default")]
        public string? FrontDefault { get; set; }

        [JsonProperty("front_shiny")]
        public string? FrontShiny { get; set; }
    }
    
    public class ShowdownDto
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
    }

    public class StatDto
    {
        [JsonProperty("base_stat")]
        public int? BaseStat { get; set; }

        [JsonProperty("effort")]
        public int? Effort { get; set; }

        [JsonProperty("stat")]
        public NamedApiResourceDto? Stat { get; set; }
    }

    public class TypeDto
    {
        [JsonProperty("slot")]
        public int? Slot { get; set; }

        [JsonProperty("type")]
        public NamedApiResourceDto? Type { get; set; }
    }

    // 이름과 URL을 가진 일반적인 리소스 객체
    public class NamedApiResourceDto
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("url")]
        public string? Url { get; set; }
    }
}