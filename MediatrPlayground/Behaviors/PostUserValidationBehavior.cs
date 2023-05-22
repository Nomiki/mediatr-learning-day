using FluentValidation;
using MediatR;
using MediatrPlayground.Models.Requests;
using MediatrPlayground.Models.Responses;

namespace MediatrPlayground.Behaviors;

public class PostUserValidationBehavior : IPipelineBehavior<PostUserRequest, PostUserResponse>
{
    private readonly IValidator<PostUserRequest> _validator;

    public PostUserValidationBehavior(IValidator<PostUserRequest> validator)
    {
        _validator = validator;
    }
    
    public async Task<PostUserResponse> Handle(PostUserRequest request, 
        RequestHandlerDelegate<PostUserResponse> next, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);
        if (validationResult.IsValid)
        {
            return await next();
        }
        
        throw new ValidationException(validationResult.Errors);
    }
}