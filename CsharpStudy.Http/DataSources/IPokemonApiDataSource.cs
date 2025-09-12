using CsharpStudy.Http.Models;
using Newtonsoft.Json;

namespace CsharpStudy.Http.DataSources;

public interface IPokemonApiDataSource<T> 
{
    Task<Response<T>> GetPokemonAsync(string pokemonName);
}

public class RemotePokemonApiDataSource : IPokemonApiDataSource<Pokemon>
{
    private const string BaseUrl = "https://pokeapi.co/api/v2/pokemon";
    private HttpClient _httpClient;

    public RemotePokemonApiDataSource(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Response<Pokemon>> GetPokemonAsync(string pokemonName)
    {
        var response = await _httpClient.GetAsync($"{BaseUrl}/{pokemonName}");
        var jsonString = await response.Content.ReadAsStringAsync();

        var headers = response.Headers.ToDictionary(
            header => header.Key,
            header => string.Join(",", header.Value)
        );
        return new Response<Pokemon>(
            statusCode: (int)response.StatusCode,
            headers: headers,
            body: JsonConvert.DeserializeObject<Pokemon>(jsonString)
        );
    }

}

