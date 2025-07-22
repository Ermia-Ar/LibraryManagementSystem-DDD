namespace Shared.Domain;
public abstract class BaseAggregateRoot<TId> : IAggregateRoot
    where TId : notnull
{
	public TId Id { get; protected set; }

	public bool IsActive { get; set; }

	public DateTime CreatedDate { get; set; }

	public DateTime? UpdatedDate { get; set; }

	public IReadOnlyCollection<IDomainEvent> Events => [.. _events];
    private readonly List<IDomainEvent> _events = [];
    public void ClearEvents() => _events.Clear();

    protected abstract void ValidateInvariants();
    protected abstract void SetStateByEvent(IDomainEvent @event);

    protected void HandleEvent<TDomainEvent>(TDomainEvent @event)
        where TDomainEvent : IDomainEvent
    {
        SetStateByEvent(@event);
        ValidateInvariants();
        _events.Add(@event);
    }

	public override bool Equals(object? obj)
		=> obj is not null &&
		   obj is BaseEntity<TId> entity &&
		   obj.GetType() == GetType() &&
		   Id.Equals(entity.Id);

	public static bool operator ==(BaseAggregateRoot<TId>? left, BaseAggregateRoot<TId>? right)
		=> left.Equals(right);

	public static bool operator !=(BaseAggregateRoot<TId>? left, BaseAggregateRoot<TId>? right)
		=> !left.Equals(right);

	public override int GetHashCode()
		=> HashCode.Combine(GetType(), Id);
}
