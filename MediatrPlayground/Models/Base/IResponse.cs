using System.Net;

namespace MediatrPlayground.Models.Base;

public interface IResponse
{
    public HttpStatusCode StatusCode { get; set; } 
    
    public string? Message { get; set; }
}