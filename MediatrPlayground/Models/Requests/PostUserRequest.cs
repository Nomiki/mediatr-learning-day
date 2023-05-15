using MediatR;
using MediatrPlayground.Models.Responses;

namespace MediatrPlayground.Models.Requests;

public class PostUserRequest : IRequest<PostUserResponse>
{
    public string? Name { get; set; }
}