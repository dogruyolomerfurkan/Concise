namespace Core.ExceptionHandler.Validation;

public sealed class ValidationException : Exception
{
    public IEnumerable<ValidationError> Errors { get; private set; }
    public ValidationException(IEnumerable<ValidationError> errors) : base(BuildErrorMessage(errors))
    {
        Errors = errors;
    }
    private static string BuildErrorMessage(IEnumerable<ValidationError> errors)
    {
        var arr = errors.Select(x => $"{Environment.NewLine} -- {x.PropertyName}: {x.ErrorMessage}");
        return "Validation failed: " + string.Join(string.Empty, arr);
    }
}