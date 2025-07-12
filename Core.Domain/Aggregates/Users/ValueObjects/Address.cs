using Shared.Domain;

namespace Core.Domain.Aggregates.Users.ValueObjects;

public class Address : ValueObject<Address>
{
	public string Street { get; private init; }
	public string City { get; private init; }
	public string PostalCode { get; private init; }
	public string Country { get; private init; }


	public static Address Create(string street, string city
		, string postalCode, string country, string? apartmentNumber = null)
	{
		if (string.IsNullOrWhiteSpace(street)) throw new ArgumentException("Street cannot be empty.", nameof(street));
		if (string.IsNullOrWhiteSpace(city)) throw new ArgumentException("City cannot be empty.", nameof(city));
		if (string.IsNullOrWhiteSpace(postalCode)) throw new ArgumentException("PostalCode cannot be empty.", nameof(postalCode));
		if (string.IsNullOrWhiteSpace(country)) throw new ArgumentException("Country cannot be empty.", nameof(country));
		if (!IsValidPostalCode(postalCode)) throw new ArgumentException("Invalid postal code format.", nameof(postalCode));

		return new Address
		{
			City = city,
			PostalCode = postalCode,
			Country = country,
			Street = street,
		};
	}

	private static bool IsValidPostalCode(string postalCode)
	{
		return !string.IsNullOrWhiteSpace(postalCode) &&
			postalCode.All(char.IsDigit) &&
			postalCode.Length >= 5 &&
			postalCode.Length <= 10;
	}

	public override IEnumerable<object> GetEqualityComponents()
	{
		yield return Street;
		yield return City;
		yield return PostalCode;
		yield return Country;
	}

	public override string ToString()
	{
		return $"{Street}, {City}, {PostalCode}, {Country}";
	}
}