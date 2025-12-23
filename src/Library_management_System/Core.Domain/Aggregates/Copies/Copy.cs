namespace Core.Domain.Aggregates.Copies;

public class Copy : BaseAggregateRoot<long>
{
	
    private Copy(long bookId, Price price,
	    PhysicalCondition physicalCondition) 
    {
        HandleEvent(
            new CopyCreatedEvent(
                bookId,
                price.ToDouble(),
                physicalCondition
                )
            );
    }

    public long BookId { get; protected set; }

    public Price Price { get; protected set; } = null!;

    public OperationalStatus OperationalStatus { get; protected set; }

    public PhysicalCondition PhysicalCondition { get; protected set; }

    public static Copy Create(long bookId,
        Price price, PhysicalCondition physicalCondition)
    {
        return new Copy(bookId,
            price, physicalCondition);
    }

    public void UpdatePhysicalCondition(PhysicalCondition physicalCondition)
    {
        HandleEvent(
            new UpdatedPhysicalConditionEvent(
                Id,
                physicalCondition
                )
            );
    }

    public void MarkAsDecommissioned()
    {
        HandleEvent(
            new MadeDecommissionedEvent(
                Id
                )
            );
    }
    
    public void MarkAsBorrowed()
    {
        HandleEvent(
            new MadeCopyBorrowedEvent(
                Id
                )
            );
    }
    
    public void MarkAsAvailable()
    {
        HandleEvent(
            new MadeCopyAvailableEvent(
                Id
                )
            );
    }
    public void MarkAsReserved()
    {
        HandleEvent(
            new MadeCopyReservedEvent(
                Id
                )
            );
    }

    public void UpdatePrice(Price newPrice)
    {
        HandleEvent(
            new UpdatedPriceEvent(
                Id,
                newPrice.ToDouble()
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
			case CopyCreatedEvent e:
				BookId = e.BookId;
				Price = Price.Create(Money.Create(e.Price));
				PhysicalCondition = e.Condition;
				OperationalStatus = OperationalStatus.Available;
				CreatedDate = DateTime.Now;
				IsActive = true;
				break;

			case UpdatedPhysicalConditionEvent e:
				PhysicalCondition = e.Condition;
				UpdatedDate = DateTime.Now;
				break;

			case MadeDecommissionedEvent:
				OperationalStatus = OperationalStatus.Decommissioned;
				UpdatedDate = DateTime.Now;
				break;
			
			case MadeCopyAvailableEvent:
				OperationalStatus = OperationalStatus.Available;
				UpdatedDate = DateTime.Now;
				break;
			
			case MadeCopyBorrowedEvent:
				OperationalStatus = OperationalStatus.Borrowed;
				UpdatedDate = DateTime.Now;
				break;
			
			case MadeCopyReservedEvent:
				OperationalStatus = OperationalStatus.Reserved;
				UpdatedDate = DateTime.Now;
				break;

			case UpdatedPriceEvent e:
				Price = Price.Create(Money.Create(e.Price));
				UpdatedDate = DateTime.Now;
				break;
		}
	}
}