using Newtonsoft.Json.Linq;
using CsharpStudy.HTTP.Models;

namespace CsharpStudy.HTTP
{
    public class RemotePokemonDataSource : IPokemonApiDataSource
    {
        private const string BaseUrl = "https://pokeapi.co";
        private readonly HttpClient _httpClient;

        public RemotePokemonDataSource(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response<Pokemon>> GetPokemonAsync(string pokemonName)
        {
            // API 호출 URL
            var url = $"{BaseUrl}/api/v2/pokemon/{pokemonName.ToLowerInvariant()}";

            // HTTP 요청/응답
            var response   = await _httpClient.GetAsync(url);
            var jsonString = await response.Content.ReadAsStringAsync();

            // 응답 헤더 -> Dictionary 변환
            var headers = response.Headers.ToDictionary(
                h => h.Key,
                h => string.Join(", ", h.Value)
            );

            // JSON 파싱
            var jo = JObject.Parse(jsonString);
            
            
            int id = 1;
            var idToken = jo["id"];
            if (idToken != null)
            {
                id = int.Parse(idToken.ToString());
            }

            string name = "unknown";
            var nameToken = jo["name"];
            if (nameToken != null)
            {
                name = nameToken.ToString();
            }

            string spriteUrl = "https://placehold.co/128";
            var spritesToken = jo["sprites"];
            if (spritesToken != null)
            {
                var frontToken = spritesToken["front_default"];
                if (frontToken != null)
                {
                    spriteUrl = frontToken.ToString();
                }
            }

            // Pokemon record 생성
            var body = new Pokemon(id, name, spriteUrl);

            // Response<T> 반환
            return new Response<Pokemon>(
                statusCode: (int)response.StatusCode,
                headers: headers,
                body: body
            );
        }
    }
}