
namespace CsharpStudy.Subway.DataSources;

public class Response<T>
{
    public int StatusCode { get; set; }

    public IReadOnlyDictionary<string,string> Headers { get; set; }

    public SeoulStationDto? Body { get; set; }

    public Response(int statusCode, IReadOnlyDictionary<string,string> headers, SeoulStationDto? body)
    {
        StatusCode = statusCode;
        Headers = headers;
        Body = body;
    }
}