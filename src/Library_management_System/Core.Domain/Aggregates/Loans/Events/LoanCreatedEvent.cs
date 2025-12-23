namespace Core.Domain.Aggregates.Loans.Events;

public sealed record LoanCreatedEvent(
	long CopyId,
	long UserId,
	DateTime BorrowDate,
	DateTime DueDate
	) : IDomainEvent
{
	public DateTime OccurredOn { get; } = DateTime.Now;
}
