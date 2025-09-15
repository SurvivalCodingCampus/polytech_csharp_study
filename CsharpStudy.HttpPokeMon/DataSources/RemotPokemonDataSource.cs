using System.Text.Json;  // Newtonsoft.Json 대신
using CsharpStudy.HttpPokeMon.DTO;
using CsharpStudy.HttpPokeMon.Models;

namespace CsharpStudy.HttpPokeMon.DataSources;

public class RemotPokemonDataSource : IPokemonApiDataSource<PokemonDTO>
{
    private const string BaseUrl = "https://pokeapi.co/api/v2/pokemon";
    private static HttpClient _httpClient;

    public RemotPokemonDataSource(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Response<PokemonDTO?>> GetPokemonAsync(string pokemonName)
    {
        var response = await _httpClient.GetAsync($"{BaseUrl}/{pokemonName}");
        var jsonString = await response.Content.ReadAsStringAsync();

        var headers = response.Headers.ToDictionary(
            header => header.Key,
            header => string.Join(", ", header.Value)
        );

        return new Response<PokemonDTO?>(
            statusCode: (int)response.StatusCode,
            headers: headers,
            body: JsonSerializer.Deserialize<PokemonDTO>(jsonString)  // 이 부분 변경!
        );
    }
}