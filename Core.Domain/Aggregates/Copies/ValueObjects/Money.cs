using Shared.Domain;

namespace Core.Domain.Aggregates.Copies.ValueObjects;

public class Money : ValueObject<Money>
{
    public double Value { get; init; }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static Money Create(double value)
    {
        return new Money { Value = value };
    }

    public static Money operator +(Money left, Money right)
    {
        return new Money { Value = left.Value + right.Value };
    }

    public static Money operator -(Money left, Money right)
    {
        return new Money { Value = left.Value - right.Value };
    }

    public override string ToString()
        => Value.ToString();
}