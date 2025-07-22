namespace Core.Domain.Filtering;

public sealed record  GetLoansFiltering(
    long? BookId,
    DateTime? BorrowDate,
    DateTime? ReturnDate,
    DateTime? DueDate,
    double? FineAmount
);