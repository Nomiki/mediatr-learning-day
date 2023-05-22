using MediatR;
using MediatrPlayground.Models.Base;
using MediatrPlayground.Models.Responses;

namespace MediatrPlayground.Models.Requests;

public class PostUserRequest : IRequest<Response<PostUserResponse>>
{
    public string? Name { get; set; }
    
    public string? Password { get; set; }
    
    public string? ConfirmPassword { get; set; }
}