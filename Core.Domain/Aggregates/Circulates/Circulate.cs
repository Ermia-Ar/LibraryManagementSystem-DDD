using Core.Domain.Aggregates.Circulates.Events;
using Core.Domain.Aggregates.Circulates.ValueObjects;
using Core.Domain.Aggregates.Copies.ValueObjects;
using Core.Domain.Aggregates.Users.ValueObjects;
using Shared.Domain;

namespace Core.Domain.Aggregates.Circulates;

public class Circulate : BaseAggregateRoot<CirculatedId>
{

	private Circulate()
	{
		
	}
    private Circulate(CirculatedId id, CopyId copyId, UserId userId,
		BorrowDate borrowDate, DueDate dueDate)
    {
		HandleEvent(
			new CirculatedCreatedEvent(
				id.ToGuid(),
				copyId.ToGuid(),
				UserId.ToGuid(),
				borrowDate.ToDateTime(),
				DueDate.ToDateTime()
				)
			);
    }

    public CopyId CopyId { get; protected set; } = null!;

	public UserId UserId { get; protected set; } = null!;

	public BorrowDate BorrowDate { get; protected set; } = null!;

	public DueDate DueDate { get; protected set; } = null!;

	public ReturnDate ReturnDate { get; protected set; } = null!;

	public FineAmount? FineAmount { get; protected set; } = null!;

	public static Circulate Create(CirculatedId id, CopyId copyId, UserId userId,
		BorrowDate borrowDate, DueDate dueDate)
	{
		return new Circulate(id, copyId, userId,
			borrowDate, dueDate);
	}

	public void Return()
	{
		HandleEvent(
			new ReturnedBookEvent(
				Id.ToGuid()
				)
			);
	}

	private FineAmount CalculateAmount()
	{
		var date = ReturnDate.Date - DueDate.Date;

		if (date <= TimeSpan.FromDays(1))
		{
			return FineAmount.Create(Money.Create(0));
		}
		return FineAmount.Create(Money.Create(date.Value.TotalDays * 10));
	}

	protected override void ValidateInvariants()
	{
		
	}

	protected override void SetStateByEvent(IDomainEvent @event)
	{
		switch (@event)
		{
			case CirculatedCreatedEvent e:
				Id = CirculatedId.Create(e.CirculatedId);
				CopyId = CopyId.Create(e.CopyId);
				UserId = UserId.Create(e.UserId);
				BorrowDate = BorrowDate.Create(e.BorrowDate);
				DueDate = DueDate.Create(e.DueDate);
				CreatedDate = DateTime.Now;
				IsActive = true;
				break;

			case ReturnedBookEvent e:
				ReturnDate = ReturnDate.Create(DateTime.Now);
				FineAmount = CalculateAmount();
				UpdatedDate = DateTime.Now;
				break;
		}
	}
}
