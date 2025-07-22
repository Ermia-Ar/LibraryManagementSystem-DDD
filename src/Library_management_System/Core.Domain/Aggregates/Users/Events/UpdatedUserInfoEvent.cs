using Shared.Domain;

namespace Core.Domain.Aggregates.Users.Events;

public sealed record UpdatedUserInfoEvent(
    long UserId,
    string FullName,
    string Street,
    string City,
    string PostalCode,
    string Country,
    string PhoneNumber,
    string Email

    ): IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.Now;
}
