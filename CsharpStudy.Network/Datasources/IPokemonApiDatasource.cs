using System.Text.Json.Serialization;
using CsharpStudy.Network.Models;
using Newtonsoft.Json;
using JsonConverter = Newtonsoft.Json.JsonConverter;

namespace CsharpStudy.Network.Interfaces;

public class IPokemonApiDatasource : IDataSource<Pokemon>
{
    private readonly HttpClient _httpClient = new HttpClient();

    public IPokemonApiDatasource()
    {
        _httpClient.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
    }


    public async Task<Response<Pokemon>> GetNameAsync(string name)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"/pokemon/{name}");

        var response = await _httpClient.SendAsync(request);
        var jsonString = await response.Content.ReadAsStringAsync();

        var headers =
            response.Headers.ToDictionary(
                header => header.Key,
                header => string.Join(", ", header.Value)
            );

        var pokemon = JsonConvert.DeserializeObject<Pokemon>(jsonString) ?? new Pokemon();
        
        return new Response<Pokemon>((int)response.StatusCode, headers, pokemon);
    }
}