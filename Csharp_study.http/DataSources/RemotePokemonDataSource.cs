using System.Text.Json.Serialization;
using Csharp_study.http.Model;
using Newtonsoft.Json;

namespace Csharp_study.http.DataSources;

public class RemotePokemonDataSource : IPokemonApiDataSource<Pokemon>
{
    private const string BaseUrl = "https://pokeapi.co/api/v2/pokemon";
    private HttpClient _httpClient;
    private IPokemonApiDataSource<Pokemon> _pokemonApiDataSourceImplementation;

    public RemotePokemonDataSource(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Response> GetPokemonAsync(string pokemonName)
    {
        var response = await _httpClient.GetAsync($"{BaseUrl}/{pokemonName}");
        var jsonString = await response.Content.ReadAsStringAsync();
        
        var headers = response.Headers.ToDictionary(
            header => header.Key,
            header => string.Join(",", header.Value)
        );
        
        return new Response(
            statusCode: (int)response.StatusCode,
            headers: headers,
            body: JsonConvert.DeserializeObject<Pokemon>(jsonString) 
        );
        
    }
}