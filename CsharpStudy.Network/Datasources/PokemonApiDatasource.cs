using System.Text.Json.Serialization;
using CsharpStudy.Network.DTOs;
using CsharpStudy.Network.Models;
using Newtonsoft.Json;
using JsonConverter = Newtonsoft.Json.JsonConverter;

namespace CsharpStudy.Network.Interfaces;

public class PokemonApiDatasource : IDataSource<PokemonDto>
{
    private readonly HttpClient _httpClient = new HttpClient();
    private const string BaseUrl = "https://pokeapi.co";

    public PokemonApiDatasource()
    {
        _httpClient.BaseAddress = new Uri(BaseUrl);
    }

    public async Task<Response<PokemonDto>> GetNameAsync(string name)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"/api/v2/pokemon/{name}");

        var response = await _httpClient.SendAsync(request);
        var jsonString = await response.Content.ReadAsStringAsync();

        var headers =
            response.Headers.ToDictionary(
                header => header.Key,
                header => string.Join(", ", header.Value)
            );
        
        var pokemon = JsonConvert.DeserializeObject<PokemonDto>(jsonString) ?? new PokemonDto();
        
        return new Response<PokemonDto>((int)response.StatusCode, headers, pokemon);
    }
}