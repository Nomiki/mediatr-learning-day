using MediatR;
using MediatrPlayground.Models.Responses;

namespace MediatrPlayground.Models.Requests;

public class GetUserRequest : IRequest<GetUserResponse>
{
    public string? UserId { get; set; }
}