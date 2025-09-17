namespace CsharpStudy.HTTP.Common;

public enum PokemonError
{
    NotFound,        // 404 대상 없음
    Network,         // 네트워크 연결 문제(HttpRequestException 등)
    Timeout,         // 요청 타임아웃(TaskCanceledException 등)
    Unknown          // 그 밖의 모든 오류
}