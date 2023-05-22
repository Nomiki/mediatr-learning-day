using MediatR;
using MediatrPlayground.Models.Base;
using MediatrPlayground.Models.Responses;

namespace MediatrPlayground.Models.Requests;

public class GetUserRequest : IRequest<Response<GetUserResponse>>
{
    public string? UserId { get; set; }
}