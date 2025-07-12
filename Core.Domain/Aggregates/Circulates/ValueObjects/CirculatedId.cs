using Shared.Domain;

namespace Core.Domain.Aggregates.Circulates.ValueObjects;

public class CirculatedId : ValueObject<CirculatedId>
{
    public Guid Id { get; init; }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }

    public static CirculatedId Create(Guid id)
    {
        return new CirculatedId { Id = id };
    }

    public Guid ToGuid()
        => Id;
}