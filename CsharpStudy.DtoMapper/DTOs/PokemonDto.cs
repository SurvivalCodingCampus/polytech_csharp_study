namespace CsharpStudy.DtoMapper.DTOs;

using Newtonsoft.Json;
using System.Collections.Generic;

public class PokemonDto
{
    [JsonProperty("abilities")]
    public List<AbilityWrapperDto>? Abilities { get; set; }

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
    public List<PastTypeDto>? PastTypes { get; set; }

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

public class AbilityWrapperDto
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
    public List<HeldItemVersionDetailDto>? VersionDetails { get; set; }
}

public class HeldItemVersionDetailDto
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
    public List<MoveVersionGroupDetailDto>? VersionGroupDetails { get; set; }
}

public class MoveVersionGroupDetailDto
{
    [JsonProperty("level_learned_at")]
    public int? LevelLearnedAt { get; set; }

    [JsonProperty("move_learn_method")]
    public NamedApiResourceDto? MoveLearnMethod { get; set; }

    [JsonProperty("order")]
    public int? Order { get; set; }

    [JsonProperty("version_group")]
    public NamedApiResourceDto? VersionGroup { get; set; }
}

public class PastAbilityDto
{
    [JsonProperty("abilities")]
    public List<AbilityWrapperDto>? Abilities { get; set; }

    [JsonProperty("generation")]
    public NamedApiResourceDto? Generation { get; set; }
}

public class PastTypeDto
{
    [JsonProperty("generation")]
    public NamedApiResourceDto? Generation { get; set; }

    [JsonProperty("types")]
    public List<TypeDto>? Types { get; set; }
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

    [JsonProperty("other")]
    public OtherSpritesDto? Other { get; set; }

    [JsonProperty("versions")]
    public VersionsDto? Versions { get; set; }
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

public class VersionsDto
{
    [JsonProperty("generation-i")]
    public GenerationIDto? GenerationI { get; set; }

    [JsonProperty("generation-ii")]
    public GenerationIIDto? GenerationII { get; set; }

    [JsonProperty("generation-iii")]
    public GenerationIIIDto? GenerationIII { get; set; }

    [JsonProperty("generation-iv")]
    public GenerationIVDto? GenerationIV { get; set; }

    [JsonProperty("generation-v")]
    public GenerationVDto? GenerationV { get; set; }

    [JsonProperty("generation-vi")]
    public GenerationVIDto? GenerationVI { get; set; }

    [JsonProperty("generation-vii")]
    public GenerationVIIDto? GenerationVII { get; set; }

    [JsonProperty("generation-viii")]
    public GenerationVIIIDto? GenerationVIII { get; set; }
}

public class GenerationIDto
{
    [JsonProperty("red-blue")]
    public RedBlueDto? RedBlue { get; set; }

    [JsonProperty("yellow")]
    public YellowDto? Yellow { get; set; }
}

public class RedBlueDto
{
    [JsonProperty("back_default")]
    public string? BackDefault { get; set; }

    [JsonProperty("back_gray")]
    public string? BackGray { get; set; }

    [JsonProperty("back_transparent")]
    public string? BackTransparent { get; set; }

    [JsonProperty("front_default")]
    public string? FrontDefault { get; set; }

    [JsonProperty("front_gray")]
    public string? FrontGray { get; set; }

    [JsonProperty("front_transparent")]
    public string? FrontTransparent { get; set; }
}

public class YellowDto
{
    [JsonProperty("back_default")]
    public string? BackDefault { get; set; }

    [JsonProperty("back_gray")]
    public string? BackGray { get; set; }

    [JsonProperty("back_transparent")]
    public string? BackTransparent { get; set; }

    [JsonProperty("front_default")]
    public string? FrontDefault { get; set; }

    [JsonProperty("front_gray")]
    public string? FrontGray { get; set; }

    [JsonProperty("front_transparent")]
    public string? FrontTransparent { get; set; }
}

public class GenerationIIDto
{
    [JsonProperty("crystal")]
    public CrystalDto? Crystal { get; set; }

    [JsonProperty("gold")]
    public GoldDto? Gold { get; set; }

    [JsonProperty("silver")]
    public SilverDto? Silver { get; set; }
}

public class CrystalDto
{
    [JsonProperty("back_default")]
    public string? BackDefault { get; set; }

    [JsonProperty("back_shiny")]
    public string? BackShiny { get; set; }

    [JsonProperty("back_shiny_transparent")]
    public string? BackShinyTransparent { get; set; }

    [JsonProperty("back_transparent")]
    public string? BackTransparent { get; set; }

    [JsonProperty("front_default")]
    public string? FrontDefault { get; set; }

    [JsonProperty("front_shiny")]
    public string? FrontShiny { get; set; }

    [JsonProperty("front_shiny_transparent")]
    public string? FrontShinyTransparent { get; set; }

    [JsonProperty("front_transparent")]
    public string? FrontTransparent { get; set; }
}

public class GoldDto
{
    [JsonProperty("back_default")]
    public string? BackDefault { get; set; }

    [JsonProperty("back_shiny")]
    public string? BackShiny { get; set; }

    [JsonProperty("front_default")]
    public string? FrontDefault { get; set; }

    [JsonProperty("front_shiny")]
    public string? FrontShiny { get; set; }

    [JsonProperty("front_transparent")]
    public string? FrontTransparent { get; set; }
}

public class SilverDto
{
    [JsonProperty("back_default")]
    public string? BackDefault { get; set; }

    [JsonProperty("back_shiny")]
    public string? BackShiny { get; set; }

    [JsonProperty("front_default")]
    public string? FrontDefault { get; set; }

    [JsonProperty("front_shiny")]
    public string? FrontShiny { get; set; }

    [JsonProperty("front_transparent")]
    public string? FrontTransparent { get; set; }
}

public class GenerationIIIDto
{
    [JsonProperty("emerald")]
    public EmeraldDto? Emerald { get; set; }

    [JsonProperty("firered-leafgreen")]
    public FireRedLeafGreenDto? FireredLeafgreen { get; set; }

    [JsonProperty("ruby-sapphire")]
    public RubySapphireDto? RubySapphire { get; set; }
}

public class EmeraldDto
{
    [JsonProperty("front_default")]
    public string? FrontDefault { get; set; }

    [JsonProperty("front_shiny")]
    public string? FrontShiny { get; set; }
}

public class FireRedLeafGreenDto
{
    [JsonProperty("back_default")]
    public string? BackDefault { get; set; }

    [JsonProperty("back_shiny")]
    public string? BackShiny { get; set; }

    [JsonProperty("front_default")]
    public string? FrontDefault { get; set; }

    [JsonProperty("front_shiny")]
    public string? FrontShiny { get; set; }
}

public class RubySapphireDto
{
    [JsonProperty("back_default")]
    public string? BackDefault { get; set; }

    [JsonProperty("back_shiny")]
    public string? BackShiny { get; set; }

    [JsonProperty("front_default")]
    public string? FrontDefault { get; set; }

    [JsonProperty("front_shiny")]
    public string? FrontShiny { get; set; }
}

public class GenerationIVDto
{
    [JsonProperty("diamond-pearl")]
    public DiamondPearlDto? DiamondPearl { get; set; }

    [JsonProperty("heartgold-soulsilver")]
    public HeartGoldSoulSilverDto? HeartgoldSoulsilver { get; set; }

    [JsonProperty("platinum")]
    public PlatinumDto? Platinum { get; set; }
}

public class DiamondPearlDto
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

public class HeartGoldSoulSilverDto
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

public class PlatinumDto
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

public class GenerationVDto
{
    [JsonProperty("black-white")]
    public BlackWhiteDto? BlackWhite { get; set; }
}

public class BlackWhiteDto
{
    [JsonProperty("animated")]
    public AnimatedDto? Animated { get; set; }

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

public class AnimatedDto
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

public class GenerationVIDto
{
    [JsonProperty("omegaruby-alphasapphire")]
    public OmegaRubyAlphaSapphireDto? OmegaRubyAlphaSapphire { get; set; }

    [JsonProperty("x-y")]
    public XYDto? XY { get; set; }
}

public class OmegaRubyAlphaSapphireDto
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

public class XYDto
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

public class GenerationVIIDto
{
    [JsonProperty("icons")]
    public IconsDto? Icons { get; set; }

    [JsonProperty("ultra-sun-ultra-moon")]
    public UltraSunUltraMoonDto? UltraSunUltraMoon { get; set; }
}

public class IconsDto
{
    [JsonProperty("front_default")]
    public string? FrontDefault { get; set; }

    [JsonProperty("front_female")]
    public string? FrontFemale { get; set; }
}

public class UltraSunUltraMoonDto
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

public class GenerationVIIIDto
{
    [JsonProperty("icons")]
    public IconsDto? Icons { get; set; }
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

public class NamedApiResourceDto
{
    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("url")]
    public string? Url { get; set; }
}