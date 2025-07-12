using Shared.Domain;
using Shared.Utility;

namespace Core.Domain.Aggregates.Users.ValueObjects;

public class PhoneNumber : ValueObject<PhoneNumber>
{
	public string Number { get; set; } = null!;
	public override IEnumerable<object> GetEqualityComponents()
	{
		yield return Number;
	}

	public static PhoneNumber Create(string number)
	{
		if (!Utilities.IsPhoneNumber(number))
		{
			throw new ArgumentException();
		}

		return new PhoneNumber { Number = number };
	}

	public override string ToString() 
		=> Number;
}