namespace CsharpStudy.HttpStudy.Repository;

public enum PokemonError
{
    NetworkError,
    NotFound,
    InvalidInput,
    UnknownError,
    TimeoutException, // 가상
    JsonSerializationException // 가상
}