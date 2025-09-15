namespace CsharpStudy.Network.Interfaces;

public class Response <T>
{
    public int Statuts {get;}
    public IReadOnlyDictionary<string, string> Headers {get;}
    public T Body { get; }

    public Response(int statuts, IReadOnlyDictionary<string, string> headers, T body)
    {
        Statuts = statuts;
        Headers = headers;
        Body = body;
    }
}