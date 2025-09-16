using Newtonsoft.Json;
using CsharpStudy.DtoMapper;

namespace CsharpStudy.HTTP
{
    public class RemotePokemonDataSource : IPokemonApiDataSource
    {
        private const string BaseUrl = "https://pokeapi.co";
        private readonly HttpClient _httpClient;

        public RemotePokemonDataSource(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<Response<PokemonDto>> GetPokemonAsync(string nameOrId)
        {
            var url = $"{BaseUrl}/api/v2/pokemon/{nameOrId.ToLowerInvariant()}";
            var response = await _httpClient.GetAsync(url);
            var jsonString = await response.Content.ReadAsStringAsync();

            var headers = response.Headers.ToDictionary(h => h.Key, h => string.Join(", ", h.Value));
            var dto = JsonConvert.DeserializeObject<PokemonDto>(jsonString) ?? new PokemonDto();

            return new Response<PokemonDto>(
                statusCode: (int)response.StatusCode,
                headers: headers,
                body: dto
            );
        }
    }
}