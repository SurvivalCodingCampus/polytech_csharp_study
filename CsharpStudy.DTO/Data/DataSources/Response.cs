namespace CsharpStudy.DTO.Data.DataSources;

public class Response<T>
{
    public int StatusCode { get; }
    public Dictionary<string, string> Headers { get; }
    public T Body { get; }

    public Response(int statusCode, Dictionary<string, string> headers, T body)
    {
        StatusCode = statusCode;
        Headers = headers;
        Body = body;
    }
}