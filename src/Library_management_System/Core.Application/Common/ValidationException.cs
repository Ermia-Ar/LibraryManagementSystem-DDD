using Shared.Exceptions;

namespace Core.Application.Common;

public class ValidationDomainException(params string[] errors) 
    : BaseValidationException(errors);