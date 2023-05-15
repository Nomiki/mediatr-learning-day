using MediatR;
using MediatrPlayground.Models.Requests;
using MediatrPlayground.Models.Responses;

namespace MediatrPlayground.Handlers;

public class GetUserHandler : IRequestHandler<GetUserRequest, GetUserResponse>
{
    public Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        GetUserResponse response = new()
        {
            UserId = request.UserId,
            Name = "John Doe"
        };
        
        return Task.FromResult(response);
    }
}