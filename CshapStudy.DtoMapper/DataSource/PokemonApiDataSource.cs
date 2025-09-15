using System.Reflection.Metadata.Ecma335;
using Newtonsoft.Json;


using CshapStudy.DtoMapper.DTOs;
namespace CshapStudy.DtoMapper.DataSource;

public class PokemonApiDataSource : IPokemonApiDataSource
{
    private const string _BaseUrl = "https://pokeapi.co/api/v2/pokemon/";
    private HttpClient _httpClient;

    public PokemonApiDataSource(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Response<PokemonDto>> GetPokemonAsync(string pokemonName)
    {
        var response = await _httpClient.GetAsync($"{_BaseUrl}/{pokemonName}");
        var jsonstring = await response.Content.ReadAsStringAsync();
        var headers = response.Headers.ToDictionary(
            header => header.Key,
            header => string.Join(",", header.Value)
        );
        
        return new Response<PokemonDto>(
            statusCode: (int)response.StatusCode,
            headers: headers,
            body: JsonConvert.DeserializeObject<PokemonDto>(jsonstring)!
        );
    }
    
}