using Newtonsoft.Json;

namespace Pokemon.DataSource;

public class MockPokemonApiFailDataSource : IPokemonApiDataSource
{
    public async Task<Response<Pokemon>> GetPokemonAsync(string pokemonName)
    {
        Pokemon pokemon = new Pokemon();
        pokemon.Name = pokemonName;
        pokemon.Sprites.other.OfficialArtwork.front_default =
            "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/1.png";

        Response<Pokemon> response = new Response<Pokemon>(
            400, new Dictionary<string, string>(), pokemon
        );

        return response;
    }
}

public class MockPokemonApiSuccessDataSource : IPokemonApiDataSource
{
    public async Task<Response<Pokemon>> GetPokemonAsync(string pokemonName)
    {
        Pokemon pokemon = new Pokemon();
        pokemon.Name = pokemonName;
        pokemon.Sprites.other.OfficialArtwork.front_default =
            "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/1.png";

        Response<Pokemon> response = new Response<Pokemon>(
            200, new Dictionary<string, string>(), pokemon
        );

        return response;
    }
}

public class PokemonApiDataSource : IPokemonApiDataSource
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://pokeapi.co/api/v2/pokemon";
    
    public PokemonApiDataSource(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Response<Pokemon>> GetPokemonAsync(string pokemonName)
    {
        var response = await _httpClient.GetAsync($"{BaseUrl}/{pokemonName}");

        var jsonString = await response.Content.ReadAsStringAsync();

        var headers = response.Headers.ToDictionary(
            header => header.Key,
            header => string.Join(", ", header.Value)
        );

        return new Response<Pokemon>(
            statusCode: (int)response.StatusCode,
            headers: headers,
            body: JsonConvert.DeserializeObject<Pokemon>(jsonString)
        );
    }
}