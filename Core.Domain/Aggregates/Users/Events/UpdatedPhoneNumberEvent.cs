using Shared.Domain;

namespace Core.Domain.Aggregates.Users.Events;

public sealed record UpdatedPhoneNumberEvent(
    Guid UserId,
    string PhoneNumber

    ): IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.Now;
}