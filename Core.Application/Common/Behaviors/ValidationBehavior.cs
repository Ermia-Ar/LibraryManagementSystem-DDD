using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Shared.Responses;

namespace Core.Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Response
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken = default(CancellationToken))
    {
        if (!validators.Any())
            return await next(cancellationToken);

        ValidationContext<TRequest> context = new ValidationContext<TRequest>(request);
        List<ValidationFailure> failures = (await Task.WhenAll(validators
            .Select(v => v.ValidateAsync(context, cancellationToken))))
            .Where(r => r.Errors.Count != 0).SelectMany(r => r.Errors).ToList();
        
        if (failures.Count != 0)
             throw new ValidationDomainException(failures.Select(x => x.ErrorMessage).ToArray());
        
        return await next(cancellationToken);
    }
}