using MediatR;
using MediatrPlayground.Models;
using MediatrPlayground.Models.Requests;
using MediatrPlayground.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace MediatrPlayground.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IMediator _mediator;

    public UserController(ILogger<UserController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult> Get([FromRoute] string userId)
    {
        GetUserRequest request = new GetUserRequest
        {
            UserId = userId,
        };
        
        GetUserResponse response = await _mediator.Send(request);
        return Ok(response);
    }
}