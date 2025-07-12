using Shared.Domain;

namespace Core.Domain.Aggregates.Users.Events;

public sealed record UpdatedAddressEvent(
    Guid UserId,
    string Street,
    string City,
    string PostalCode,
    string Country

    ): IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.Now;
}
