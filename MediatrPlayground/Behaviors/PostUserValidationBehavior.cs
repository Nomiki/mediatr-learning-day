using FluentValidation;
using MediatR;
using MediatrPlayground.Models.Base;
using MediatrPlayground.Models.Requests;
using MediatrPlayground.Models.Responses;

namespace MediatrPlayground.Behaviors;

public class PostUserValidationBehavior : IPipelineBehavior<PostUserRequest, Response<PostUserResponse>>
{
    private readonly IValidator<PostUserRequest> _validator;

    public PostUserValidationBehavior(IValidator<PostUserRequest> validator)
    {
        _validator = validator;
    }
    
    public async Task<Response<PostUserResponse>> Handle(PostUserRequest request, 
        RequestHandlerDelegate<Response<PostUserResponse>> next, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid)
        {
            return await next();
        }
        
        string errorsString = validationResult.Errors
            .Select(x => x.ErrorMessage)
            .Aggregate((x, y) => $"{x}, {y}");

        return Response<PostUserResponse>.Error(errorsString);
    }
}