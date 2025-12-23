namespace Core.Application.ApplicationServices.Users.Queries.GetLoans;

public sealed record GetLoansForUserQueryRequest(
    long UserId,
    PaginationFiltering PaginationFiltering,
    GetLoansFiltering Filtering
) : IQuery<PaginatedResult<GetLoansForUserQueryResponse>>
{
    public static GetLoansForUserQueryRequest Create(long userId, GetLoansForUserQueryRequestDto model)
        => new GetLoansForUserQueryRequest(
            userId,
            new PaginationFiltering(
                model.PageNum, model.PageSize
                ),
            new GetLoansFiltering(
                model.BookId, model.BorrowDate, 
                model.ReturnDate, model.DueDate,
                model.FineAmount
                )
        );
}
    
    
public sealed record GetLoansForUserQueryRequestDto(
    int PageNum,
    int PageSize,
    long? BookId,
    DateTime? BorrowDate,
    DateTime? ReturnDate,
    DateTime? DueDate,
    double? FineAmount
    );