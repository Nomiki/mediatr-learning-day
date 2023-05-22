using MediatR;
using MediatrPlayground.Models.Requests;
using MediatrPlayground.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace MediatrPlayground.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : MyControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IMediator _mediator;

    public UserController(ILogger<UserController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet("{userId}")]
    public async Task<IResult> Get([FromRoute] string userId)
    {
        GetUserRequest request = new GetUserRequest
        {
            UserId = userId,
        };
        
        var response = await _mediator.Send(request);
        return HandleResponse(response);
    }
    
    [HttpPost]
    public async Task<IResult> Post([FromBody] PostUserRequest request)
    {
        var response = await _mediator.Send(request);
        return HandleResponse(response);
    }
}