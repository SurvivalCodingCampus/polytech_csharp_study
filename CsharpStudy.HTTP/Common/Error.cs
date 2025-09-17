namespace CsharpStudy.HTTP.Common;

public record Error(
    PokemonError Kind,     // 어떤 종류의 에러인지
    string Message,        // 구체적인 에러 메시지
    Exception? Exception = null // 실제 발생한 예외 객체 (있으면)
    );