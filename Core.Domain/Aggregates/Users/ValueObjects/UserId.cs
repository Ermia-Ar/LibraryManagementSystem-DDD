using Shared.Domain;

namespace Core.Domain.Aggregates.Users.ValueObjects;

public class UserId : ValueObject<UserId>
{
    public Guid Id { get; init; }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }

    public static UserId Create(Guid id)
    {
        return new UserId { Id = id};
    }

    public Guid ToGuid()
        => Id;  
}