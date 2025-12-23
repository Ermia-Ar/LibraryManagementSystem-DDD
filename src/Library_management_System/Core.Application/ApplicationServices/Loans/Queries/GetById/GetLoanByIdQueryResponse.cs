namespace Core.Application.ApplicationServices.Loans.Queries.GetById;

public sealed record GetLoanByIdQueryResponse(
    string BookName,
    string UserFullName,
    DateTime BorrowDate,
    DateTime DueDate,
    DateTime ReturnDate,
    double FineAmount
) : IResponse;