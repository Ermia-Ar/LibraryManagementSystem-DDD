using Core.Domain.Aggregates.Reservations.Events;

namespace Core.Domain.Aggregates.Reservations;

public class Reservation : BaseAggregateRoot<long>
{
	public Reservation()
	{
		
	}
	
    private Reservation(long copyId, long userId,
		ReservationDate reservationDate)
    {
		HandleEvent(
			new ReservationCreatedEvent(
				copyId,
				userId,
				reservationDate.ToDateTime()
				)
			);
    }
    public long CopyId { get; protected set; }

	public long UserId { get; protected set; }

	public ReservationDate ReservationDate { get; protected set; } = null!;

	public ReservationStatus Status { get; protected set; }

	public static Reservation Create(long copyId,
		long userId, ReservationDate date)
	{
		return new Reservation(copyId, userId, date);
	}

	public void Expire()
	{
		if (Status != ReservationStatus.Pending)
			throw new InvalidDateDomainException("This reservation is already cancelled");
		
		HandleEvent(
			new ReservationExpiredEvent(
				Id
				)
			);
	}

	public void Cancel()
	{
		if (Status != ReservationStatus.Pending)
			throw new InvalidDateDomainException("This reservation is already cancelled");
		
		HandleEvent(
			new ReservationCancelledEvent(
				Id
				)
			);
	}

	public void Complete()
	{
		if (Status != ReservationStatus.Pending)
			throw new InvalidDateDomainException("This reservation is already cancelled");
		
		HandleEvent(
			new ReservationCompletedEvent(
				Id
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
			case ReservationCreatedEvent e:
				CopyId = e.CopyId;
				UserId = e.UserId;
				ReservationDate = ReservationDate.Create(e.ReservationDate);
				Status = ReservationStatus.Pending;
				CreatedDate = DateTime.Now;
				IsActive = true;
				break;

			case ReservationCancelledEvent:
				Status = ReservationStatus.Cancelled;
				UpdatedDate = DateTime.Now;
				break;

			case ReservationCompletedEvent:
				Status = ReservationStatus.Completed;	
				UpdatedDate = DateTime.Now;
				break;

			case ReservationExpiredEvent:
				Status = ReservationStatus.Expired;
				UpdatedDate = DateTime.Now;
				break;
		}
	}
}
