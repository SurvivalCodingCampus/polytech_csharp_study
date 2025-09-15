using CshapStudy.DtoMapper.DTOs;

namespace CshapStudy.DtoMapper.DataSource;

public class Response<T>
{
    public int StatusCode { get; set; }
    public object Headers { get; set; }
    public T Body { get; set; }

    public Response(int statusCode, object headers, T body)
    {
        StatusCode = statusCode;
        Headers = headers; 
        Body = body;
        
    }
}