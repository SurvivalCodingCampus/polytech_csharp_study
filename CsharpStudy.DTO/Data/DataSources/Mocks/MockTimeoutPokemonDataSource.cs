namespace CsharpStudy.DTO.Data.DataSources.Mocks;

public class MockTimeoutPokemonDataSource
{
    private string baseUrl = "https://pokeapi.co/api/v2/pokemon/";
    HttpClient _httpClient;
    
    public MockTimeoutPokemonDataSource(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Response<PokemonDto>> GetPokemonAsync(string pokemonName)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"{baseUrl}{pokemonName}");
        
        return new Response<PokemonDto>(
            statusCode: 408,
            headers: new Dictionary<string, string> { { "Content-Type", "application/json" } },
            body: new PokemonDto()
        );
    }
}