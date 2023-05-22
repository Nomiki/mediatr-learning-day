using MediatrPlayground.Models.Base;

namespace MediatrPlayground.Utils;

public interface IResponseParserService
{
    IResult ParseResponse<T>(Response<T> response);
}