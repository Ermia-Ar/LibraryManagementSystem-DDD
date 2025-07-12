using Core.Domain.Aggregates.Books.ValueObjects;
using Core.Domain.Aggregates.Copies.Enums;
using Core.Domain.Aggregates.Copies.Events;
using Core.Domain.Aggregates.Copies.ValueObjects;
using Shared.Domain;

namespace Core.Domain.Aggregates.Copies;

public class Copy : BaseAggregateRoot<CopyId>
{
	private Copy()
	{
		
	}
	
    private Copy(CopyId copyId, BookId bookId
        , Price price, PhysicalCondition physicalCondition) 
    {
        HandleEvent(
            new CopyCreatedEvent(
                copyId.ToGuid(),
                bookId.ToGuid(),
                price.ToDouble(),
                physicalCondition
                )
            );
    }

    public BookId BookId { get; protected set; } = null!;

    public Price Price { get; protected set; } = null!;

    public OperationalStatus OperationalStatus { get; protected set; }

    public PhysicalCondition PhysicalCondition { get; protected set; }

    public static Copy Create(CopyId id, BookId bookId,
        Price price, PhysicalCondition physicalCondition)
    {
        return new Copy(id, bookId,
            price, physicalCondition);
    }

    public void UpdatePhysicalCondition(PhysicalCondition physicalCondition)
    {
        HandleEvent(
            new UpdatedPhysicalConditionEvent(
                Id.ToGuid(),
                BookId.ToGuid(),
                physicalCondition
                )
            );
    }

    public void UpdateOperationalStatus(OperationalStatus status)
    {
        HandleEvent(
            new UpdatedOperationalStatusEvent(
                Id.ToGuid(),
                BookId.ToGuid(),
                status
                )
            );
    }

    public void UpdatePrice(Price newPrice)
    {
        HandleEvent(
            new UpdatedPriceEvent(
                Id.ToGuid(),
                BookId.ToGuid(),
                newPrice.ToDouble()
                )
            );
    }

	protected override void ValidateInvariants()
	{
		throw new NotImplementedException();
	}

	protected override void SetStateByEvent(IDomainEvent @event)
	{
		switch (@event)
		{
			case CopyCreatedEvent e:
				Id = CopyId.Create(e.CopyId);
				BookId = BookId.Create(e.BookId);
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

			case UpdatedOperationalStatusEvent e:
				OperationalStatus = OperationalStatus.Available;
				UpdatedDate = DateTime.Now;
				break;

			case UpdatedPriceEvent e:
				Price = Price.Create(Money.Create(e.Price));
				UpdatedDate = DateTime.Now;
				break;
		}
	}
}