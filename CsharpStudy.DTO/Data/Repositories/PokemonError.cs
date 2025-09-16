namespace CsharpStudy.DTO.Data.Repositories;

public enum PokemonError
{
    NetworkTimeout,
    NotFound,
    Unknown,
    AuthenticationFailed,
    JsonSerializationFailed
}