using Newtonsoft.Json;

namespace _250912.Data.DataSource;

public class PokemonDataSource : IPokemonApiDataSource<Pokemon>
{
    private const string BaseUrl = "https://pokeapi.co/api/v2/pokemon";
    private HttpClient _httpClient;
    
    public PokemonDataSource(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<Response> GetPokemonAsync(string pokemonName)
    {
        var response = await _httpClient.GetAsync($"{BaseUrl}/{pokemonName}");
        var jsonString = await response.Content.ReadAsStringAsync();
        
        var headers = response.Headers.ToDictionary(
            header => header.Key,
            header => string.Join(", ", header.Value)
        );
        
        return new Response(
            statusCode: (int)response.StatusCode,
            headers: headers,
            body: JsonConvert.DeserializeObject<Pokemon>(jsonString)
        );

    }
}