using Shared.Domain;

namespace Core.Domain.Aggregates.Copies.ValueObjects;

public class Price : ValueObject<Price>
{
    public Money Moeny { get; init; } = null!;
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Moeny;
    }

    public static Price Create(Money money)
    {
        if (money.Value <= 0)
        {
            throw new ArgumentNullException(nameof(money), "Price must be greater than zero");
        }

        return new Price { Moeny = money };
    }

    public override string ToString()
        => Moeny.Value.ToString();

    public double ToDouble()
        => Moeny.Value;
}