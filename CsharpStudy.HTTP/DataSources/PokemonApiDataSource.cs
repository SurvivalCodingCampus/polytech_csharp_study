using CsharpStudy.Http.Models;
using Newtonsoft.Json;

namespace CsharpStudy.Http.DataSources;

public class PokemonApiDataSource : IPokemonApiDataSource<Pokemon>
{
    private const string BaseUrl = "https://pokeapi.co/api/v2/pokemon/";
    private HttpClient _httpClient;

    public PokemonApiDataSource(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<Response<Pokemon>> GetPokemonAsync(string pokemonName)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"{BaseUrl}/{pokemonName}");
        
        string jsonString = await response.Content.ReadAsStringAsync();
        
        Dictionary<string, string> headers = response.Headers.ToDictionary(
            header => header.Key,
            header => string.Join(",", header.Value)
        );

        return new Response<Pokemon>(
            statusCode: (int) response.StatusCode,
            headers: headers,
            body: JsonConvert.DeserializeObject<Pokemon>(jsonString) ?? new Pokemon()
        );
    }
}