using Shared.Domain;

namespace Core.Domain.Aggregates.Loans.Events;

public sealed record ReturnedCopyEvent(
	long LoanId

	) : IDomainEvent
{
	public DateTime OccurredOn { get; } = DateTime.Now;
}
