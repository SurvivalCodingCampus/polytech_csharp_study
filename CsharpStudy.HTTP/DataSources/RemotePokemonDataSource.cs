using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;    
using CsharpStudy.HTTP.Models;

namespace CsharpStudy.HTTP
{
    public class RemotePokemonDataSource : IPokemonApiDataSource
    {
        private const string BaseUrl = "https://pokeapi.co";
        private HttpClient _httpClient;

        public RemotePokemonDataSource(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response<Pokemon>> GetPokemonAsync(string pokemonName)
        {
            var url = $"{BaseUrl}/api/v2/pokemon/{pokemonName.ToLowerInvariant()}";

            var response   = await _httpClient.GetAsync(url);
            var jsonString = await response.Content.ReadAsStringAsync();

            var headers = response.Headers.ToDictionary(
                h => h.Key,
                h => string.Join(", ", h.Value)
            );
            
            
            var jo = JObject.Parse(jsonString);
            var body = new Pokemon
            {
                name     = (string?)jo["name"],
                imageUrl = (string?)jo["sprites"]?["front_default"]
            };

            return new Response<Pokemon>(
                statusCode: (int)response.StatusCode,
                headers: headers,
                body: body
            );
        }
    }
}