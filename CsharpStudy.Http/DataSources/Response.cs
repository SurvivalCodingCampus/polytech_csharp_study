namespace CsharpStudy.Http.DataSources;

public class Response<T>
{
    public int StatusCode { get; }  // 응답 코드 200, 404, 500 등
    public IReadOnlyDictionary<string, string>  Headers { get; }  // 헤더 정보들
    public T Body { get; }  // 내용

    public Response(int statusCode, IReadOnlyDictionary<string, string> headers, T body)
    {
        StatusCode = statusCode;
        Headers = headers;
        Body = body;
    }
}