namespace Core.Domain.Aggregates.Loans;

public class Loan : BaseAggregateRoot<long>
{
    private Loan(long copyId, long userId,
		BorrowDate borrowDate, DueDate dueDate)
    {
		HandleEvent(
			new LoanCreatedEvent(
				copyId,
				userId,
				borrowDate.ToDateTime(),
				dueDate.ToDateTime()
				)
			);
    }

    public long CopyId { get; protected set; } 

	public long UserId { get; protected set; } 

	public BorrowDate BorrowDate { get; protected set; } = null!;

	public DueDate DueDate { get; protected set; } = null!;
	//ef 
	public ReturnDate? ReturnDate { get; protected set; }

	public FineAmount? FineAmount { get; protected set; }

	public static Loan Create(long copyId, long userId,
		BorrowDate borrowDate, DueDate dueDate)
	{
		return new Loan(copyId, 
			userId,borrowDate, dueDate);
	}

	public bool IsReturned()
	{
		return FineAmount is not null;
	}

	public void Return()
	{
		HandleEvent(
			new ReturnedCopyEvent(
				Id
				)
			);
	}

	private FineAmount CalculateAmount()
	{
		if (ReturnDate is null)
			throw new InvalidDateDomainException(nameof(ReturnDate));
		
		var date = ReturnDate.Date - DueDate.Date;

		if (date <= TimeSpan.FromDays(1))
		{
			return FineAmount.Create(Money.Create(0));
		}
		
		return FineAmount.Create(Money.Create(date.TotalDays * 10));
	}

	protected override void ValidateInvariants()
	{
		//check state of oof entity
		//for example we cant have fineAmount Without ReturnDate
	}

	protected override void SetStateByEvent(IDomainEvent @event)
	{
		switch (@event)
		{
			case LoanCreatedEvent e:
				CopyId = e.CopyId;
				UserId = e.UserId;
				BorrowDate = BorrowDate.Create(e.BorrowDate);
				DueDate = DueDate.Create(e.DueDate);
				CreatedDate = DateTime.Now;
				IsActive = true;
				break;

			case ReturnedCopyEvent:
				ReturnDate = ReturnDate.Create(DateTime.Now);
				FineAmount = CalculateAmount();
				UpdatedDate = DateTime.Now;
				break;
		}
	}
}
