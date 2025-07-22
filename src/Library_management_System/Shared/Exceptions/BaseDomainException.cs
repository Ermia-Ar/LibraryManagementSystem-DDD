namespace Shared.Exceptions;

public abstract class BaseDomainException(params string[] errors) : Exception
{
    public List<string> Errors { get; set; } = errors.ToList();
}
public abstract class BaseValidationException(params string[] errors) : Exception
{
    public List<string> Errors { get; set; } = errors.ToList();
}
