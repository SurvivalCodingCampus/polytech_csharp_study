using _250915.Data.Models;
using Newtonsoft.Json;

namespace _250915.Data.DataSources;

public class PokemonApiDataSource : IPokemonApiDataSource<Pokemon>
{
    private const string BaseUrl = "https://pokeapi.co/api/v2/pokemon";
    private HttpClient _httpClient;

    public PokemonApiDataSource(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<Response> GetPokemonAsync(string pokemonName)
    {
        var response = await _httpClient.GetAsync($"{BaseUrl}/{pokemonName}");
        var jsonString = await response.Content.ReadAsStringAsync();

        var headers = response.Headers.ToDictionary(
            h => h.Key,
            h => string.Join(", ", h.Value));

        return new Response(
            statusCode:(int)response.StatusCode,
            headers: headers,
            body: JsonConvert.DeserializeObject<PokemonDto>(jsonString)
        );

    }
    
}