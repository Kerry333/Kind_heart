using Kind_heart.Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Kind_heart.API.Extensions;

public static class ResponsExtensions
{
    public static ActionResult ToErrorResponse(this Error error)
    {
        var statusCode = error.Type switch
        {
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Failure => StatusCodes.Status500InternalServerError,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError
        };
        
        return new ObjectResult(error)
        {
            StatusCode = statusCode
        };
    }
}