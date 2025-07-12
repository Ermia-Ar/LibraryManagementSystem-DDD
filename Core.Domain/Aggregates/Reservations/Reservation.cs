using Core.Domain.Aggregates.Copies.ValueObjects;
using Core.Domain.Aggregates.Reservations.Enums;
using Core.Domain.Aggregates.Reservations.Events;
using Core.Domain.Aggregates.Reservations.ValueObjects;
using Core.Domain.Aggregates.Users.ValueObjects;
using Shared.Domain;

namespace Core.Domain.Aggregates.Users;

public class Reservation : BaseAggregateRoot<ReservationId>
{
	private Reservation()
	{
		
	}
	
    private Reservation(ReservationId id, CopyId copyId, UserId userId,
		ReservationDate reservationDate)
    {
		HandleEvent(
			new ReservationCreatedEvent(
				id.ToGuid(),
				copyId.ToGuid(),
				userId.ToGuid(),
				reservationDate.ToDateTime()
				)
			);
    }
    public CopyId CopyId { get; protected set; } = null!;

	public UserId UserId { get; protected set; } = null!;

	public ReservationDate ReservationDate { get; protected set; } = null!;

	public ReservationStatus Status { get; protected set; }

	public static Reservation Create(ReservationId id,
		CopyId copyId, UserId userId, ReservationDate date)
	{
		return new Reservation(id, copyId, userId, date);
	}

	public void MakeExpired()
	{
		HandleEvent(
			new MakedExpiredReservationEvent(
				Id.ToGuid()
				)
			);
	}

	public void MakeCancelled()
	{
		HandleEvent(
			new MakedCancelledReservationEvent(
				Id.ToGuid()
				)
			);
	}

	public void MakeCompleted()
	{
		HandleEvent(
			new MakedCompletedReservationEvent(
				Id.ToGuid()
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
				Id = ReservationId.Create(e.ReservationId);
				CopyId = CopyId.Create(e.CopyId);
				UserId = UserId.Create(e.UserId);
				ReservationDate = ReservationDate.Create(e.ReservationDate);
				Status = ReservationStatus.Pending;
				CreatedDate = DateTime.Now;
				IsActive = true;
				break;

			case MakedCancelledReservationEvent e:
				Status = ReservationStatus.Cancelled;
				UpdatedDate = DateTime.Now;
				break;

			case MakedCompletedReservationEvent e:
				Status = ReservationStatus.Completed;	
				UpdatedDate = DateTime.Now;
				break;

			case MakedExpiredReservationEvent e:
				Status = ReservationStatus.Expired;
				UpdatedDate = DateTime.Now;
				break;
		}
	}
}
