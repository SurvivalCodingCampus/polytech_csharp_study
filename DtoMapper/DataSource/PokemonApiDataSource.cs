using Newtonsoft.Json;

namespace DtoMapper.DataSource;

public class PokemonApiDataSource : IPokemonApiDataSource
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://pokeapi.co/api/v2/pokemon";
    
    public PokemonApiDataSource(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Response<PokemonDto>> GetPokemonAsync(string pokemonName)
    {
        var response = await _httpClient.GetAsync($"{BaseUrl}/{pokemonName}");

        var jsonString = await response.Content.ReadAsStringAsync();

        var headers = response.Headers.ToDictionary(
            header => header.Key,
            header => string.Join(", ", header.Value)
        );

        return new Response<PokemonDto>(
            statusCode: (int)response.StatusCode,
            headers: headers,
            body: JsonConvert.DeserializeObject<PokemonDto>(jsonString)
        );
    }
}