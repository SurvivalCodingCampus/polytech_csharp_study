namespace CsharpStudy.DtoMapper.Repositories;

public enum PokemonError
{
    NetworkError,
    NotFound,
    InvalidInput,
    UnknownError,
    TimeoutException, // 항상 타임 아웃
    JsonSerializationException // Json 데이터를 C#객체로 변환(역직렬화), c#을 Json으로 변환(직렬화) 과정에서 문제 발생 에러 
}