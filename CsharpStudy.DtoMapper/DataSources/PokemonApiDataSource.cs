//using CsharpStudy.DtoMapper.DTO;

using CsharpStudy.Http.DataSource;
using Newtonsoft.Json;

namespace CsharpStudy.DtoMapper.DataSources;

/// IPokemonApiDataSource 인터페이스의 실제 구현체입니다.
/// HttpClient를 사용하여 실제 PokeAPI와 HTTP 통신을 수행합니다.
public class PokemonApiDataSource : IPokemonApiDataSource // 데이터 통신 담당
{
    private const string BaseUrl = "https://pokeapi.co/api/v2/pokemon"; // PokeAPI의 기본 URL을 상수로 정의합니다.
    private HttpClient _httpClient; // HTTP 요청을 보내기 위한 HttpClient 인스턴스입니다.

    public PokemonApiDataSource(HttpClient httpClient) /// 생성자, 외부에서 HttpClient 인스턴스를 주입받습니다.
    {
        _httpClient = httpClient;
    }

    /// PokeAPI에 특정 포켓몬의 데이터를 요청하고, 그 결과를 Response<PokemonDto> 형태로 반환합니다.
    public async Task<Response<PokemonDto>> GetPokemonAsync(string pokemonName)
    {
        // GetAsync를 사용하여 비동기적으로 API에 GET 요청을 보냅니다.
        var response = await _httpClient.GetAsync($"{BaseUrl}/{pokemonName}");

        var jsonString = await response.Content.ReadAsStringAsync(); // 응답 본문을 문자열(JSON) 형태로 비동기적으로 읽어옵니다.

        // 응답 헤더를 Dictionary 형태로 변환하여 저장합니다.
        var headers = response.Headers.ToDictionary(
            header => header.Key,
            header => string.Join(", ", header.Value)
        );

        // 최종적으로 상태 코드, 헤더, 그리고 JSON 문자열을 PokemonDto로 역직렬화한 본문을 담은
        // Response 객체를 생성하여 반환합니다.
        return new Response<PokemonDto>(
            statusCode: (int)response.StatusCode,
            headers: headers,
            body: JsonConvert.DeserializeObject<PokemonDto>(jsonString)!
            // JsonConvert.DeserializeObject를 사용해 JSON 문자열을 PokemonDto 객체로 변환합니다.
            // '!'는 이 결과가 null이 아님을 컴파일러에게 알려주는 것입니다.
        );
    }
}