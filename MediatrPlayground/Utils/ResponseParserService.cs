using MediatrPlayground.Models.Base;

namespace MediatrPlayground.Utils;

public class ResponseParserService : IResponseParserService
{
    public IResult ParseResponse<T>(Response<T> response)
    {
        if (response.Data is not null)
        {
            return Results.Json(response.Data, statusCode: (int)response.StatusCode);
        }

        return Results.Problem(response.Message, statusCode: (int)response.StatusCode);
    }
}