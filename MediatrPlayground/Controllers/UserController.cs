using MediatrPlayground.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediatrPlayground.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "{userId}")]
    public ActionResult Get([FromRoute] string userId)
    {
        return Ok(new UserModel
        {
            UserId = userId,
            Name = "John Doe",
        });
    }
}