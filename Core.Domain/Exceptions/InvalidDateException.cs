using Shared.Exceptions;

namespace Core.Domain.Exceptions;

public class InvalidDateDomainException(params string[] errors)
    : BaseDomainException(errors);