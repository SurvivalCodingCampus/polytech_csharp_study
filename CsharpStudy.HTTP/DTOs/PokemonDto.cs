using System.Text.Json.Serialization;

namespace CsharpStudy.HTTP.DTOs;

public sealed record PokemonDto(
    [property: JsonPropertyName("id")]   int Id,
    [property: JsonPropertyName("name")] string Name
);