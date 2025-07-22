using Core.Domain.Aggregates.Copies;
using Core.Domain.Aggregates.Copies.Enums;
using Core.Domain.Aggregates.Loans;
using Core.Domain.Aggregates.Loans.ValueObjects;
using Core.Domain.Aggregates.Reservations;
using Core.Domain.Aggregates.Users;

namespace Core.Domain.Services;

public static class LoanServices
{
    public static (Loan loan, string? errorMessage) CreateLoan(
        User user, Copy copy, DueDate dueDate, Reservation? reservation = null)
    {
        // Check status
        if (copy.OperationalStatus is OperationalStatus.Borrowed
            or OperationalStatus.Decommissioned)
        {
            return (null!, "Copy status is not available");
        }

        // If reserved, only allow if reservation is for this user
        if (copy.OperationalStatus == OperationalStatus.Reserved)
        {
            if (reservation is null || reservation.UserId != user.Id)
                return (null!, "This copy is reserved");

            reservation.Complete();
        }

        copy.MarkAsBorrowed();

        var loan = Loan.Create(copy.Id,
            user.Id, BorrowDate.Create(DateTime.Now), dueDate);
        
        return (loan, null);
    }

    public static string? Return(Loan loan, Copy copy)
    {
        if (loan.IsReturned())
            return "Loan already returned";
        
        loan.Return();
        copy.MarkAsBorrowed();

        return null;
    }
}