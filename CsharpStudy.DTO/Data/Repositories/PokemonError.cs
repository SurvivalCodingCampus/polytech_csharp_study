namespace CsharpStudy.DTO.Data.Repositories;

public enum PokemonError
{
    NetworkTimeout = 401,
    NotFound = 404,
    Unknown = -2,
    AuthenticationFailed = 404,
    JsonSerializationFailed = -1,
}