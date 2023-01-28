using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.ExceptionHandler.Validation;

public sealed class ValidationErrorDetails : ProblemDetails
{
    public object Errors { get; set; } = default!;
    public ValidationErrorDetails(string messages)
    {
        Status = StatusCodes.Status400BadRequest;
        Type = "Validation Exception";
        Title = "Validation Error";
        Errors = messages;
    }
}