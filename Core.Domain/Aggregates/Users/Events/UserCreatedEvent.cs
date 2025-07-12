using Core.Domain.Aggregates.Users.Enums;
using Shared.Domain;

namespace Core.Domain.Aggregates.Users.Events;

public sealed record UserCreatedEvent(
    Guid UserId,
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
