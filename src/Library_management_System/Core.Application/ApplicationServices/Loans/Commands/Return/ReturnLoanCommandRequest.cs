using Shared.Mediator.Command;

namespace Core.Application.ApplicationServices.Loans.Commands.Return;

public sealed record ReturnLoanCommandRequest(
    long LoanId
    ) : ICommand;