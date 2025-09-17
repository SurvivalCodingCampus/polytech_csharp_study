using CsharpStudy.HttpStudy.DataSources;
using CsharpStudy.HttpStudy.DTO;
using Newtonsoft.Json;

namespace CsharpStudy.HttpStudy.Data;

public class RemotePostDataSource : IPokemonApiDataSource
{
    private const string BaseUrl = "https://pokeapi.co/api/v2/pokemon";
    private HttpClient _httpClient;
    
    public RemotePostDataSource(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Response<PokemonDto>> GetPokemonAsync(string pokemonName)
    {
        var response = await _httpClient.GetAsync($"{BaseUrl}/{pokemonName}");
        //Console.WriteLine($"HTTP {(int)response.StatusCode}");

        var jsonString = await response.Content.ReadAsStringAsync();
        //Console.WriteLine($"Body: {jsonString.Substring(0, Math.Min(200, jsonString.Length))}");


        var headers = response.Headers.ToDictionary(
            header => header.Key,
            header => string.Join(", ", header.Value)
        );
        
        PokemonDto? body = null;
        if (response.IsSuccessStatusCode) // 2xx 일 때만 파싱
        {
            body = JsonConvert.DeserializeObject<PokemonDto>(jsonString);
        }
        
        return new Response<PokemonDto>(
            statusCode: (int)response.StatusCode,
            headers: headers,
            body: body
        );
    }
}