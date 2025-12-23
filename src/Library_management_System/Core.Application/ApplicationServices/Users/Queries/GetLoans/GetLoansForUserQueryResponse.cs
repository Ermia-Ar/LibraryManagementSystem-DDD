namespace Core.Application.ApplicationServices.Users.Queries.GetLoans;

public sealed record GetLoansForUserQueryResponse(
    string BookName,
    string UserFullName,
    DateTime BorrowDate,
    DateTime DueDate,
    DateTime ReturnDate,
    double FineAmount
) : IResponse;