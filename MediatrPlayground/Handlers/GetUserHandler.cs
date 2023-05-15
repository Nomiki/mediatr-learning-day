using MediatR;
using MediatrPlayground.Dal;
using MediatrPlayground.Models.Requests;
using MediatrPlayground.Models.Responses;

namespace MediatrPlayground.Handlers;

public class GetUserHandler : IRequestHandler<GetUserRequest, GetUserResponse>
{
    private readonly IUserRepository _userRepository;

    public GetUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        var userDocument = await _userRepository.GetUser(request.UserId!);

        if (userDocument is null)
        {
            throw new NullReferenceException($"User with id {request.UserId} not found");
        }
        
        GetUserResponse response = new()
        {
            UserId = userDocument.Id,
            Name = userDocument.Name
        };
        
        return response;
    }
}