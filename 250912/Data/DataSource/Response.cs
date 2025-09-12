namespace _250912.Data.DataSource;

public class Response
{
    public int StatusCode { get; set; }
    public IReadOnlyDictionary<string, string> Headers { get; set; }
    public Pokemon Body { get; set; }

    public Response(int statusCode, IReadOnlyDictionary<string, string> headers, Pokemon body)
    {
        StatusCode = statusCode;
        Headers = headers;
        Body = body;
    }


}