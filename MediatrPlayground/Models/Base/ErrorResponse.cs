using System.Net;

namespace MediatrPlayground.Models.Base;

public class ErrorResponse : IResponse
{
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    
    public string? Message { get; set; }
}