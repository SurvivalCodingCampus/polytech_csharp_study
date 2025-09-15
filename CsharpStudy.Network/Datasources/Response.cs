namespace CsharpStudy.Network.Interfaces;

public class Response <T>
{
    public int Status {get;}
    public IReadOnlyDictionary<string, string> Headers {get;}
    public T Body { get; }

    public Response(int status, IReadOnlyDictionary<string, string> headers, T body)
    {
        Status = status;
        Headers = headers;
        Body = body;
    }
}