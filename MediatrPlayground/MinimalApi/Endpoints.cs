using MediatR;
using MediatrPlayground.Models.Base;
using MediatrPlayground.Models.Requests;
using MediatrPlayground.Utils;
using Microsoft.AspNetCore.Mvc;

namespace MediatrPlayground.MinimalApi;

public static class Endpoints
{
    public static WebApplication AddUserEndpoints(this WebApplication app)
    {
        app.MapGet("/api/v2/user/{userId}",
                async ([FromServices] IMediator mediator,
                    [FromServices] IResponseParserService responseParserService,
                    [AsParameters] GetUserRequest request,
                    CancellationToken cancellationToken) =>
                {
                    var response = await mediator.Send(request, cancellationToken);
                    return responseParserService.ParseResponse(response);
                })
            .WithDescription("Gets a user")
            .WithTags("User v2")
            .WithName("GetUser_v2");

        app.MapPost("/api/v2/user",
                async ([FromServices] IMediator mediator,
                    [FromServices] IResponseParserService responseParserService,
                    [FromBody] PostUserRequest request,
                    CancellationToken cancellationToken) =>
                {
                    var response = await mediator.Send(request, cancellationToken);
                    return responseParserService.ParseResponse(response);
                })
            .WithDescription("Creates a user")
            .WithTags("User v2")
            .WithName("PostUser_v2");

        return app;
    }
}