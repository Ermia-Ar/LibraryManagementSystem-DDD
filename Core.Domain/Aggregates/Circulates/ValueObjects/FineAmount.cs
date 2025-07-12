using Core.Domain.Aggregates.Copies.ValueObjects;
using Shared.Domain;

namespace Core.Domain.Aggregates.Circulates.ValueObjects;

public class FineAmount : ValueObject<FineAmount>
{
	public Money Money { get; init; }

	public override IEnumerable<object> GetEqualityComponents()
	{
		yield return Money;
	}

	public static FineAmount Create(Money money)
	{
		if (money.Value < 0)
		{
			throw new ArgumentException();
		}

		return new FineAmount { Money = money };
	}

	public double ToDouble() 
		=> Money.Value;
}