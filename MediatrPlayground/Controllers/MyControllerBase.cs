using MediatrPlayground.Models;
using MediatrPlayground.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace MediatrPlayground.Controllers;

public class MyControllerBase : ControllerBase
{
    protected IResult HandleResponse<T>(Response<T> response)
    {
        if (response.Data is not null)
        {
            return Results.Json(response.Data, statusCode: (int)response.StatusCode);
        }

        return Results.Problem(response.Message, statusCode: (int)response.StatusCode);
    }
}