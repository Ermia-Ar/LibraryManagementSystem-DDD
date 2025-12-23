namespace Core.Application.ApplicationServices.Loans.Queries.GetById;

public sealed record GetLoanByIdQueryRequest(
    long LoanId
    ) : IQuery<GetLoanByIdQueryResponse>;