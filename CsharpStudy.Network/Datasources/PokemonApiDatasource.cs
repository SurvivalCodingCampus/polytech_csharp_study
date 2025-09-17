using CsharpStudy.Network.DTOs;
using CsharpStudy.Network.Interfaces;
using Newtonsoft.Json;

namespace CsharpStudy.Network.Datasources;

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

        return TryDeserializeJson(jsonString, response, headers);
    }

    private static Response<PokemonDto> TryDeserializeJson(string jsonString, HttpResponseMessage response,
        Dictionary<string, string> headers)
    {
        try
        {
            var pokemon = JsonConvert.DeserializeObject<PokemonDto>(jsonString) ?? new PokemonDto();
            return new Response<PokemonDto>((int)response.StatusCode, headers, pokemon);
        }
        catch (JsonSerializationException e)
        {
            if ((int)response.StatusCode != 200)
                return new Response<PokemonDto>((int)response.StatusCode, headers, new PokemonDto());
            throw;
        }
        catch (Exception e)
        {
            return new Response<PokemonDto>((int)response.StatusCode, headers, new PokemonDto());
        }
    }
}