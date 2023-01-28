using Core.ExceptionHandler.Authorization;
using Core.ExceptionHandler.Business;
using Core.ExceptionHandler.Internal;
using Core.ExceptionHandler.Validation;
using Microsoft.AspNetCore.Mvc;

namespace Core.ExceptionHandler;

public static class ErrorResponseFactory
{
    public static ProblemDetails CreateErrorReponse(Exception exception)
    {
        ProblemDetails response = exception switch
        {
            AuthorizationException => new AuthorizationErrorDetails(exception.Message),
            BusinessException => new BusinessErrorDetails(exception.Message),
            ValidationException => new ValidationErrorDetails(exception.Message),
            _ => new InternalErrorDetails(exception.Message)
        };

        return response;
    }
}