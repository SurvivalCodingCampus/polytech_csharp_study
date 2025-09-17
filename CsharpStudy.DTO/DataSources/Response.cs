using CsharpStudy.DTO.DTOs;
using CsharpStudy.DTO.Model;

namespace CsharpStudy.DTO.DataSources;

public class Response<T>
{
    public  int StatusCode { get; set; }
    public IReadOnlyDictionary<string, string> Headers { get; set; }
    public T Body { get; set; }

    public Response(int statusCode, IReadOnlyDictionary<string, string> headers, T body)
    {
        StatusCode = statusCode;
        Headers = headers;
        Body = body;
    }
}
