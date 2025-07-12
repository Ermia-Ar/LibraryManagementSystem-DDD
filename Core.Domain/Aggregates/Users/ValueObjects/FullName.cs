using Shared.Domain;

namespace Core.Domain.Aggregates.Users.ValueObjects;

public class FullName : ValueObject<FullName>
{
	public string Name { get; init; }
	public override IEnumerable<object> GetEqualityComponents()
	{
		yield return Name;
	}
	public static FullName Create(string name)
	{
		if (name.Length < 3)
		{
			throw new ArgumentException();
		}
		
		 return new FullName { Name = name };
	}

	public override string ToString()
		=> Name;
}