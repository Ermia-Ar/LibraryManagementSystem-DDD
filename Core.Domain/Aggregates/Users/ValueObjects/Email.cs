using Shared.Domain;
using Shared.Utilities;

namespace Core.Domain.Aggregates.Users.ValueObjects;

public class Email : ValueObject<Email>
{
	public string Value { get; init; } = null!;

	public override IEnumerable<object> GetEqualityComponents()
	{
		yield return Value;
	}

	public static Email Create(string email)
	{
		if (!Utilities.IsEmail(email))
		{
			throw new ArgumentException("Format Email");
		}

		return new Email { Value = email };
	}

	public override string ToString()
		=> Value;
}