namespace Core.Domain.Aggregates.Users.Events;

public sealed record UserCreatedEvent(
    string FullName,
    Sex Sex,
	string Street,
	string City,
	string PostalCode,
	string Country,
    string PhoneNumber,
    string Email

	) : IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.Now;
}
