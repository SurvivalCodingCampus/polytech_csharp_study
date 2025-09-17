using System.Net.Http.Json;
using CsharpStudy.HTTP.DTOs;

namespace CsharpStudy.HTTP.DataSources;

public sealed class RemotePokemonDataSource(HttpClient http) : IPokemonApiDataSource
{
    private const string Base = "https://pokeapi.co/api/v2/pokemon/";

    public async Task<PokemonDto?> GetPokemonAsync(string name)
    {
        return await http.GetFromJsonAsync<PokemonDto>($"{Base}{name}");
    }
}