using Newtonsoft.Json;

namespace CsharpStudy.DTO.DTOs;

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

    // Ability 정보를 담는 DTO
    public class AbilitySlotDto
    {
        [JsonProperty("is_hidden")]
        public bool? IsHidden { get; set; }

        [JsonProperty("slot")]
        public int? Slot { get; set; }

        [JsonProperty("ability")]
        public NamedResourceDto? Ability { get; set; }
    }

    // 이름과 URL을 가진 리소스 DTO
    public class NamedResourceDto
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("url")]
        public string? Url { get; set; }
    }

    // 게임 인덱스 정보를 담는 DTO
    public class GameIndexDto
    {
        [JsonProperty("game_index")]
        public int? GameIndex { get; set; }

        [JsonProperty("version")]
        public NamedResourceDto? Version { get; set; }
    }

    // 소지 아이템 정보를 담는 DTO
    public class HeldItemDto
    {
        [JsonProperty("item")]
        public NamedResourceDto? Item { get; set; }

        [JsonProperty("version_details")]
        public List<HeldItemVersionDetailDto>? VersionDetails { get; set; }
    }

    // 소지 아이템 버전 상세 DTO
    public class HeldItemVersionDetailDto
    {
        [JsonProperty("rarity")]
        public int? Rarity { get; set; }

        [JsonProperty("version")]
        public NamedResourceDto? Version { get; set; }
    }

    // Moves 정보를 담는 DTO
    public class MoveSlotDto
    {
        [JsonProperty("move")]
        public NamedResourceDto? Move { get; set; }

        [JsonProperty("version_group_details")]
        public List<MoveVersionDetailDto>? VersionGroupDetails { get; set; }
    }

    // Moves 버전 상세 DTO
    public class MoveVersionDetailDto
    {
        [JsonProperty("level_learned_at")]
        public int? LevelLearnedAt { get; set; }

        [JsonProperty("version_group")]
        public NamedResourceDto? VersionGroup { get; set; }

        [JsonProperty("move_learn_method")]
        public NamedResourceDto? MoveLearnMethod { get; set; }
    }

    // Stat 정보를 담는 DTO
    public class StatSlotDto
    {
        [JsonProperty("base_stat")]
        public int? BaseStat { get; set; }

        [JsonProperty("effort")]
        public int? Effort { get; set; }

        [JsonProperty("stat")]
        public NamedResourceDto? Stat { get; set; }
    }

    // Type 정보를 담는 DTO
    public class TypeSlotDto
    {
        [JsonProperty("slot")]
        public int? Slot { get; set; }

        [JsonProperty("type")]
        public NamedResourceDto? Type { get; set; }
    }

    // Sprites 정보를 담는 DTO
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

        [JsonProperty("other")]
        public OtherDto? Other { get; set; }

        [JsonProperty("versions")]
        public VersionsDto? Versions { get; set; }
    }

    // Other 스프라이트 정보를 담는 DTO
    public class OtherDto
    {
        [JsonProperty("dream_world")]
        public DreamWorldDto? DreamWorld { get; set; }

        [JsonProperty("official-artwork")]
        public OfficialArtworkDto? OfficialArtwork { get; set; }
    }

    // 드림 월드 스프라이트 DTO
    public class DreamWorldDto
    {
        [JsonProperty("front_default")]
        public string? FrontDefault { get; set; }

        [JsonProperty("front_female")]
        public string? FrontFemale { get; set; }
    }

    // Official Artwork 스프라이트 DTO
    public class OfficialArtworkDto
    {
        [JsonProperty("front_default")]
        public string? FrontDefault { get; set; }
    }

    // Versions 스프라이트 정보를 담는 DTO
    public class VersionsDto
    {
        [JsonProperty("generation-i")]
        public GenerationIDto? GenerationI { get; set; }
        
        // 여기에 다른 세대(generation) DTO를 추가할 수 있습니다.
    }

    // Generation I DTO
    public class GenerationIDto
    {
        [JsonProperty("red-blue")]
        public RedBlueDto? RedBlue { get; set; }

        [JsonProperty("yellow")]
        public YellowDto? Yellow { get; set; }
    }

    // Red/Blue DTO
    public class RedBlueDto
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

    // Yellow DTO
    public class YellowDto
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
    