﻿namespace CsharpStudy.HTTP;

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