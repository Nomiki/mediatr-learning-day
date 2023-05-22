using System.Net;

namespace MediatrPlayground.Models.Base;

public class Response<T> : IResponse<T>
{
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    
    public string? Message { get; set; }
    
    public T Data { get; set; } = default!;

    public static Response<T> Ok(T data) => new()
    {
        StatusCode = HttpStatusCode.OK,
        Data = data
    };
    
    public static Response<T> WithData(T data, HttpStatusCode statusCode = HttpStatusCode.OK) => new()
    {
        StatusCode = statusCode,
        Data = data
    };
    
    public static Response<T> Error(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest) => new()
    {
        StatusCode = statusCode,
        Message = message
    };
}