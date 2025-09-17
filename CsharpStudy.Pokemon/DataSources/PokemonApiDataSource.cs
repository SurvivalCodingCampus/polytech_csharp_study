using Newtonsoft.Json;

namespace CsharpStudy.Pokemon.DataSources;

public class MockPokemonApiFailDataSource : IPokemonApiDataSource
{
    public async Task<Response<Models.Pokemon>> GetPokemonAsync(string pokemonName)
    {
        Models.Pokemon pokemon = new Models.Pokemon();
        pokemon.name = pokemonName;
        pokemon.sprites.other.OfficialArtwork.front_default =
            "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/1.png";

        Response<Models.Pokemon> response = new Response<Models.Pokemon>(
            400, new Dictionary<string, string>(), pokemon
        );

        return response;
    }
}

public class MockPokemonApiSuccessDataSource : IPokemonApiDataSource
{
    public async Task<Response<Models.Pokemon>> GetPokemonAsync(string pokemonName)
    {
        Models.Pokemon pokemon = new Models.Pokemon();
        pokemon.name = pokemonName;
        pokemon.sprites.other.OfficialArtwork.front_default =
            "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/1.png";

        Response<Models.Pokemon> response = new Response<Models.Pokemon>(
            200, new Dictionary<string, string>(), pokemon
        );

        return response;
    }
}

public class PokemonApiDataSource : IPokemonApiDataSource
{
    private const string BaseUrl = "https://pokeapi.co/api/v2/pokemon";
    private HttpClient _httpClient;

    public PokemonApiDataSource(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Response<Models.Pokemon>> GetPokemonAsync(string pokemonName)
    {
        var response = await _httpClient.GetAsync($"{BaseUrl}/{pokemonName}");

        var jsonString = await response.Content.ReadAsStringAsync();

        var headers = response.Headers.ToDictionary(
            header => header.Key,
            header => string.Join(", ", header.Value)
        );

        return new Response<Models.Pokemon>(
            statusCode: (int)response.StatusCode,
            headers: headers,
            body: JsonConvert.DeserializeObject<Models.Pokemon>(jsonString)
        );
    }
}