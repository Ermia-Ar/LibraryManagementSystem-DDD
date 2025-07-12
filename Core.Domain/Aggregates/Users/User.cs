using System.Runtime.InteropServices;
using Core.Domain.Aggregates.Users.Enums;
using Core.Domain.Aggregates.Users.Events;
using Core.Domain.Aggregates.Users.ValueObjects;
using Shared.Domain;

namespace Core.Domain.Aggregates.Users;

public class User : BaseAggregateRoot<UserId>
{
	private User()
	{
		
	}
	
	private User(UserId id, FullName name, Sex sex, 
		Address address, PhoneNumber number, Email email) 
    {
		HandleEvent(
			new UserCreatedEvent(
				id.ToGuid(),
				name.ToString(),
				sex,
				address.Street,
				address.City,
				address.PostalCode,
				address.Country,
				number.ToString(),
				email.ToString()
				)
			);
    }

	public FullName Name { get; protected set; } = null!;	

	public Sex Sex { get; protected set; }

	public Address Address { get; protected set; } = null!;

	public PhoneNumber PhoneNumber { get; protected set; } = null!;

	public Email Email { get; protected set; } = null!;


	public static User Create(UserId id, FullName name, Sex sex,
		Address address, PhoneNumber number, Email email)
	{
		return new User(id, name,
			sex, address, number, email);
	}

	public void UpdateAddress(Address address)
	{
		HandleEvent(
			new UpdatedAddressEvent(
				Id.ToGuid(),
				address.Street,
				address.City,
				address.PostalCode,
				address.Country
				)
			);
	}

	public void UpdatePhoneNumber(PhoneNumber number)
	{
		HandleEvent(
			new UpdatedPhoneNumberEvent(
				Id.ToGuid(),
				number.ToString()
				)
			);
	}

	protected override void ValidateInvariants()
	{
	}

	protected override void SetStateByEvent(IDomainEvent @event)
	{
		switch (@event)
		{
			case UserCreatedEvent e:
				Id = UserId.Create(e.UserId);
				Name = FullName.Create(e.FullName);
				Sex = e.Sex;
				Address = Address.Create(e.Street, e.City, e.PostalCode, e.Country);
				PhoneNumber = PhoneNumber.Create(e.PhoneNumber);
				Email = Email.Create(e.Email);
				CreatedDate = DateTime.Now;
				IsActive = true;
				break;
		}
	}
}
