using Core.ExceptionHandler.Validation;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Core.ValidationHandler;

public class ValidationFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState.Where(p => p.Value.Errors.Count > 0).SelectMany(p => p.Value.Errors).Select(p => p.ErrorMessage).ToList();
            throw new ValidationException(errors);
        }
        await next();
    }
}