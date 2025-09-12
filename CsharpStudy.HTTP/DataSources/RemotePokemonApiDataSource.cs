using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
using CsharpStudy.HTTP.Models;

namespace CsharpStudy.HTTP.DataSource
{
    public class RemotePokemonApiDataSource : IPokemonApiDataSource
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://pokeapi.co/api/v2/pokemon/";

        public RemotePokemonApiDataSource(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response<Pokemon>> GetPokemonAsync(string pokemonName)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}{pokemonName}");
            var jsonString = await response.Content.ReadAsStringAsync();

            var headers = response.Headers.ToDictionary(
                h => h.Key,
                h => string.Join(",", h.Value)
            );

            var pokemon = JsonConvert.DeserializeObject<Pokemon>(jsonString);

            return new Response<Pokemon>(
                (int)response.StatusCode,
                headers,
                pokemon!
            );
        }
    }
}