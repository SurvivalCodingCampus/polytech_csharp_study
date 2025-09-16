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
        int readiedStatusCode = (int) response.StatusCode;
        
        Dictionary<string, string> headers = response.Headers.ToDictionary(
            header => header.Key,
            header => string.Join(",", header.Value)
        );

        string dataStringForm = await response.Content.ReadAsStringAsync();
        
        PokemonDto pokemonDto;
        try
        {
            pokemonDto = JsonConvert.DeserializeObject<PokemonDto>(dataStringForm);
        }
        catch
        {
            readiedStatusCode = -1;
            pokemonDto = new PokemonDto();
        }

        return new Response<PokemonDto>(
            statusCode: readiedStatusCode,
            headers: headers,
            body: pokemonDto
        );
    }
}