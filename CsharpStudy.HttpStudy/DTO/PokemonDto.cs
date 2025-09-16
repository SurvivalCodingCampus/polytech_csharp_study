namespace CsharpStudy.HttpStudy.DTO;

using Newtonsoft.Json;
using System.Collections.Generic;


    // 최상위 DTO: 이름과 스프라이트 정보만 가짐
    public class PokemonDto
    {
        [JsonProperty("name")] public string? Name { get; set; }

        [JsonProperty("sprites")] public SpritesDto? Sprites { get; set; }
    }

    // 스프라이트 DTO: 'Other' 정보만 가짐
    public class SpritesDto
    {
        [JsonProperty("other")] public OtherSpritesDto? Other { get; set; }
    }

    // 'Other' DTO: 'OfficialArtwork' 정보만 가짐
    // JSON의 'official-artwork' 속성을 C#의 OfficialArtwork 속성에 매핑
    public class OtherSpritesDto
    {
        [JsonProperty("official-artwork")] public OfficialArtworkDto? OfficialArtwork { get; set; }
    }

    // 공식 아트워크 DTO: 최종 이미지 URL만 가짐
    public class OfficialArtworkDto
    {
        [JsonProperty("front_default")] public string? FrontDefault { get; set; }
    }
