using CsharpStudy.HttpPokeMon.Models;
namespace CsharpStudy.HttpPokeMon.DataSources;

using Newtonsoft.Json;

public class RemotPokemonDataSource : IPokemonApiDataSource <Pokemon>
{
    private const string BaseUrl = "https://pokeapi.co/api/v2/pokemon/";
    private static HttpClient _httpClient;

    public RemotPokemonDataSource(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<Response<Pokemon>> GetPokemonAsync(string pokemonName)
    {
        var response = await _httpClient.GetAsync($"{BaseUrl}/{pokemonName}");
        var jsonString = await response.Content.ReadAsStringAsync();

        var headers = response.Headers.ToDictionary(
            header => header.Key,
            header => string.Join(", ", header.Value)
        );
        
        return new Response<Pokemon>(
            statusCode: (int)response.StatusCode,
            headers: headers,
            body: JsonConvert.DeserializeObject<Pokemon>(jsonString)
        );
    }
}