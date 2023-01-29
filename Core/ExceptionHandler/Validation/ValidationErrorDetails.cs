using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.ExceptionHandler.Validation;

public sealed class ValidationErrorDetails : ProblemDetails
{
    public object Errors { get; set; } = default!;
    public ValidationErrorDetails(Exception exception)
    {
        var validationException = exception as ValidationException;

        Status = StatusCodes.Status400BadRequest;
        Type = "Validation Exception";
        Title = "Validation Error";
        Errors = validationException?.Errors!;
    }
}