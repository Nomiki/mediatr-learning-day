using System.Net;

namespace MediatrPlayground.Models.Base;

public interface IResponse<T>
{
    public HttpStatusCode StatusCode { get; set; } 
    
    public string? Message { get; set; }
    
    public T Data { get; set; }
}