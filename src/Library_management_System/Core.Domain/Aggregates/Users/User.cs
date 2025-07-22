using System.Data;
using Core.Domain.Aggregates.Users.Enums;
using Core.Domain.Aggregates.Users.Events;
using Core.Domain.Aggregates.Users.ValueObjects;
using Core.Domain.Exceptions;
using Shared.Domain;

namespace Core.Domain.Aggregates.Users;

public class User : BaseAggregateRoot<long>
{
	private User()
	{
		_loanIds = [];
		_reservationIds = [];
	}
	
	private User(FullName name, Sex sex, 
		Address address, PhoneNumber number, Email email) 
    {
	    _loanIds = [];
	    _reservationIds = [];
	    
		HandleEvent(
			new UserCreatedEvent(
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
	

	private readonly List<long> _loanIds;
	public IReadOnlyList<long> LoanIds => [.._loanIds];
	

	private readonly List<long> _reservationIds;
	public IReadOnlyList<long> ReservationIds => [.._reservationIds];


	public static User Create(FullName name, Sex sex,
		Address address, PhoneNumber number, Email email)
	{
		return new User(name,
			sex, address, number, email);
	}

	public void AddLoansId(long checkedOutId)
	{
		if (_loanIds.Count + _reservationIds.Count > 10)
			throw new InvalidDateDomainException("Checked outs and reservations cant be greater than 10");
		
		HandleEvent(
			new LoanIdAddedEvent(
				Id,
				checkedOutId
				)
			);
	}

	public void AddReservationId(long reservationId)
	{
		if (_loanIds.Count + _reservationIds.Count > 10)
			throw new InvalidDateDomainException("Checked outs and reservations cant be greater than 10");
		
		HandleEvent(
			new ReservationIdAddedEvent(
				Id,
				reservationId
				)
			);
	}

	public void UpdateInfo(FullName fullName
		,PhoneNumber number, Address address, Email email)
	{
		HandleEvent(
			new UpdatedUserInfoEvent(
				Id,
				fullName.ToString(),
				address.Street,
				address.City,
				address.PostalCode,
				address.Country,
				number.ToString(),
				email.ToString()
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
				Name = FullName.Create(e.FullName);
				Sex = e.Sex;
				Address = Address.Create(e.Street, e.City, e.PostalCode, e.Country);
				PhoneNumber = PhoneNumber.Create(e.PhoneNumber);
				Email = Email.Create(e.Email);
				CreatedDate = DateTime.Now;
				IsActive = true;
				break;
			
			case UpdatedUserInfoEvent e:
				Address = Address.Create(e.Street, e.City, e.PostalCode, e.Country);
				Name = FullName.Create(e.FullName);
				Address = Address.Create(e.Street, e.City, e.PostalCode, e.Country);
				PhoneNumber = PhoneNumber.Create(e.PhoneNumber);
				Email = Email.Create(e.Email);
				UpdatedDate = DateTime.UtcNow;
				break;
			
			case ReservationIdAddedEvent e:
				_reservationIds.Add(e.ReservationId);
				UpdatedDate = DateTime.Now;
				break;
			
			case LoanIdAddedEvent e:
				_loanIds.Add(e.CheckOutId);
				UpdatedDate = DateTime.Now;
				break;
		}
	}
}
