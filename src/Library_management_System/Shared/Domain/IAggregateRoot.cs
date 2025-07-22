namespace Shared.Domain;

public interface IAggregateRoot
{
    IReadOnlyCollection<IDomainEvent> Events { get; }

    void ClearEvents();
}
