using System.Net;
using MediatR;
using MediatrPlayground.Dal;
using MediatrPlayground.Dal.Models;
using MediatrPlayground.Models;
using MediatrPlayground.Models.Base;
using MediatrPlayground.Models.Requests;
using MediatrPlayground.Models.Responses;
using MediatrPlayground.Utils;

namespace MediatrPlayground.Handlers;

public class PostUserHandler : IRequestHandler<PostUserRequest, Response<PostUserResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public PostUserHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }
    
    public async Task<Response<PostUserResponse>> Handle(PostUserRequest request, CancellationToken cancellationToken)
    { 
        UserDocument user = new()
        {
            Name = request.Name,
            PasswordHash = _passwordHasher.Hash(request.Password!)
        };
        var userDocument = await _userRepository.PostUser(user);
        
        PostUserResponse response = new()
        {
            UserId = userDocument.Id,
            Name = userDocument.Name
        };
        
        return Response<PostUserResponse>.WithData(response, HttpStatusCode.Created);
    }
}