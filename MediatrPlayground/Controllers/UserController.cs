using MediatR;
using MediatrPlayground.Models.Base;
using MediatrPlayground.Models.Requests;
using MediatrPlayground.Models.Responses;
using MediatrPlayground.Utils;
using Microsoft.AspNetCore.Mvc;

namespace MediatrPlayground.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IMediator _mediator;
    private readonly IResponseParserService _responseParserService;

    public UserController(ILogger<UserController> logger, IMediator mediator, IResponseParserService responseParserService)
    {
        _logger = logger;
        _mediator = mediator;
        _responseParserService = responseParserService;
    }

    [HttpGet("{userId}")]
    public async Task<IResult> Get([FromRoute] string userId)
    {
        GetUserRequest request = new GetUserRequest
        {
            UserId = userId,
        };
        
        Response<GetUserResponse> response = await _mediator.Send(request);
        return _responseParserService.ParseResponse(response);
    }
    
    [HttpPost]
    public async Task<IResult> Post([FromBody] PostUserRequest request)
    {
        Response<PostUserResponse> response = await _mediator.Send(request);
        return _responseParserService.ParseResponse(response);
    }
}