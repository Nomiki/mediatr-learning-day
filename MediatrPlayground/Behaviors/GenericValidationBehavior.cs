using System.Net;
using FluentValidation;
using MediatR;
using MediatrPlayground.Models.Base;

namespace MediatrPlayground.Behaviors;

public class GenericValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IResponse, new()
{
    private readonly IValidator<TRequest>? _validator;

    public GenericValidationBehavior(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }
    
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validator is null)
        {
            return await next();
        }
        
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid)
        {
            return await next();
        }
        
        string errorsString = validationResult.Errors
            .Select(x => x.ErrorMessage)
            .Aggregate((x, y) => $"{x}, {y}");
        
        ErrorResponse errorResponse = new ErrorResponse
        {
            StatusCode = HttpStatusCode.BadRequest,
            Message = errorsString
        };
        
        return (dynamic)errorResponse;
    }
}