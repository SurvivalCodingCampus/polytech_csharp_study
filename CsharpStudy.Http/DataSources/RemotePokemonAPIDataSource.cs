using CsharpStudy.Http.Models;
using Newtonsoft.Json;

namespace CsharpStudy.Http.DataSources;

public class RemotePokemonAPIDataSource : IPokemonApiDataSource
{
    private const string BaseUrl = "https://pokeapi.co/api/v2/pokemon/";
    private readonly HttpClient _httpClient;

    public RemotePokemonAPIDataSource(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }


    public async Task<P_Response<Pokemon>> GetPokemonAsync(string pokemonName)
    {
        var response = await _httpClient.GetAsync($"{BaseUrl}/{pokemonName}");

        var jsonString = await response.Content.ReadAsStringAsync();

        var headers = response.Headers.ToDictionary(
            header => header.Key,
            header => string.Join(", ", header.Value)
        );

        return new P_Response<Models.Pokemon>(
            statusCode: (int)response.StatusCode,
            headers: headers,
            body: JsonConvert.DeserializeObject<Models.Pokemon>(jsonString)
        );
    }
}