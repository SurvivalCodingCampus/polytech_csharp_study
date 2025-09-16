using CsharpStudy.DTO.Data.Models;
using Newtonsoft.Json;

namespace CsharpStudy.DTO.Data.DataSources;

public class PokemonDataSource : IPokemonDataSource
{
    private string _baseUrl = "https://pokeapi.co/api/v2/pokemon/";
    private HttpClient _httpClient;

    public PokemonDataSource(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<Response<PokemonDto>> GetPokemonAsync(string pokemonName)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"{_baseUrl}{pokemonName}");

        string dataStringForm = await response.Content.ReadAsStringAsync();
        
        PokemonDto pokemonDto;
        try
        {
            pokemonDto = JsonConvert.DeserializeObject<PokemonDto>(dataStringForm);
        }
        catch
        {
            pokemonDto = new PokemonDto();
        }

        Dictionary<string, string> headers = response.Headers.ToDictionary(
            header => header.Key,
            header => string.Join(",", header.Value)
        );

        return new Response<PokemonDto>(
            statusCode: (int)response.StatusCode,
            headers: headers,
            body: pokemonDto
        );
    }
}