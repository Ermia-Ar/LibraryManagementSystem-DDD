using MediatR;

namespace Shared.Domain;
public interface IDomainEvent : INotification
{
    DateTime OccurredOn { get; }
}

public interface IDomainEventHandler<T> : INotificationHandler<T>
    where T : IDomainEvent
{

}