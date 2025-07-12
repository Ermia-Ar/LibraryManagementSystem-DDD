namespace Shared.Domain;

public abstract class BaseEntity<TId>
    (Action<IDomainEvent> applire) where TId : notnull
{
	public TId Id { get; protected set; }


    private Action<IDomainEvent> _applier = applire;

	public bool IsActive { get; set; }

	public DateTime CreatedDate { get; set; }

	public DateTime? UpdatedDate { get; set; }

	public void HandleEvent(IDomainEvent @event)
    {
        SetStatusByEvent(@event);
        _applier(@event);
    }

    protected abstract void SetStatusByEvent(IDomainEvent @event);

   
    
    public override bool Equals(object? obj)
        => obj is not null &&
           obj is BaseEntity<TId> entity &&
           obj.GetType() == GetType() &&
           Id.Equals(entity.Id);

    public static bool operator ==(BaseEntity<TId> left, BaseEntity<TId> right)
        => left.Equals(right);

    public static bool operator !=(BaseEntity<TId> left, BaseEntity<TId> right)
        => !left.Equals(right);

    public override int GetHashCode()
        => HashCode.Combine(GetType(), Id);
}