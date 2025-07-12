using Shared.Domain;

namespace Core.Domain.Aggregates.Copies.ValueObjects;

public class CopyId : ValueObject<CopyId>
{
    public Guid Id { get; init; }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }

    public static CopyId Create(Guid id)
        => new CopyId { Id = id };

    public Guid ToGuid()
        => Id;
}