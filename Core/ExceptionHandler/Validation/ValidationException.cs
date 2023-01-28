namespace Core.ExceptionHandler.Validation;

public sealed class ValidationException : Exception
{
    public IEnumerable<string> Errors { get; private set; }
    public ValidationException(IEnumerable<string> errors) : base(BuildErrorMessage(errors))
    {
        Errors = errors;
    }
    private static string BuildErrorMessage(IEnumerable<string> errors)
    {
        var arr = errors.Select(x => $"{Environment.NewLine} -- {x}");
        return "Validation failed: " + string.Join(string.Empty, arr);
    }
}