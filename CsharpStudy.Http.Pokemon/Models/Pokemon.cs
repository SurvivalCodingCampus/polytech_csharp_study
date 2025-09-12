using Newtonsoft.Json;

namespace CsharpStudy.Http.Pokemon.Models;
// JSON 데이터를 다루기 위한 라이브러리

// namespace CsharpStudy.Http.Pokemon.Models;
// 최종 목표인 "front_default" URL을 담는 클래스입니다.
// JSON 경로: sprites -> other -> official-artwork -> front_default
public class OfficialArtwork
{
    [JsonProperty("front_default")] public string FrontDefault { get; set; }
}

// "official-artwork" 객체를 담는 "other" 클래스입니다.
// JSON 경로: sprites -> other
public class Other
{
    [JsonProperty("official-artwork")] public OfficialArtwork OfficialArtwork { get; set; }
}

// "other" 객체를 담는 최상위 "sprites" 클래스입니다.
// JSON 경로: sprites
public class Sprites
{
    [JsonProperty("other")] public Other Other { get; set; }
}

// 전체 JSON 구조의 시작점인 Pokemon 클래스입니다.
public class Pokemon
{
    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("sprites")] public Sprites Sprites { get; set; }
}