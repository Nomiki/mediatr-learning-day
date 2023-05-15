using MediatR;
using MediatrPlayground.Dal;
using MediatrPlayground.Dal.Models;
using MediatrPlayground.Models;
using MediatrPlayground.Models.Requests;
using MediatrPlayground.Models.Responses;

namespace MediatrPlayground.Handlers;

public class PostUserHandler : IRequestHandler<PostUserRequest, PostUserResponse>
{
    private readonly IUserRepository _userRepository;

    public PostUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<PostUserResponse> Handle(PostUserRequest request, CancellationToken cancellationToken)
    { 
        UserDocument user = new()
        {
            Name = request.Name,
        };
        var userDocument = await _userRepository.PostUser(user);
        
        PostUserResponse response = new()
        {
            UserId = userDocument.Id,
            Name = userDocument.Name
        };
        
        return response;
    }
}