using System.Net;
using MediatR;
using MediatrPlayground.Dal;
using MediatrPlayground.Models;
using MediatrPlayground.Models.Base;
using MediatrPlayground.Models.Requests;
using MediatrPlayground.Models.Responses;

namespace MediatrPlayground.Handlers;

public class GetUserHandler : IRequestHandler<GetUserRequest, Response<GetUserResponse>>
{
    private readonly IUserRepository _userRepository;

    public GetUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Response<GetUserResponse>> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        var userDocument = await _userRepository.GetUser(request.UserId!);

        if (userDocument is null)
        {
            return Response<GetUserResponse>.Error($"User with id {request.UserId} not found", HttpStatusCode.NotFound);
        }

        GetUserResponse getUserResponse = new GetUserResponse
        {
            UserId = userDocument.Id,
            Name = userDocument.Name
        };
        
        return Response<GetUserResponse>.Ok(getUserResponse);
    }
}