namespace CsharpStudy.Result.DataSources;

/// API 응답을 감싸는 제네릭 클래스입니다.
/// 응답 본문(Body) 외에도 상태 코드(StatusCode), 헤더(Headers) 등 추가 정보를 함께 담을 수 있습니다.
/// /// <typeparam name="T">응답 본문의 데이터 타입</typeparam>
public class Response<T>
{
    public int StatusCode { get; }
    public IReadOnlyDictionary<string, string> Headers { get; }
    public T Body { get; }

    public Response(int statusCode, IReadOnlyDictionary<string, string> headers, T body)
    {
        StatusCode = statusCode;
        Headers = headers;
        Body = body;
    }
}