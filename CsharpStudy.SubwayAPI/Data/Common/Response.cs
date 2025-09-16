namespace CsharpStudy.StationAPI.Data.Common;

public class Response<T>
{
    public int StatusCode { get; init; }
    public Dictionary<string, string> Headers { get; init; }
    public T Body { get; init; }
    
    public Response(int statusCode, Dictionary<string, string> header, T body)
    {
        StatusCode = statusCode;
        Headers = header;
        Body = body;
    }
}