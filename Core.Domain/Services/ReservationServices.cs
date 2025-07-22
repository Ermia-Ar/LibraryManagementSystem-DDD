using Core.Domain.Aggregates.Copies;
using Core.Domain.Aggregates.Copies.Enums;
using Core.Domain.Aggregates.Reservations;
using Core.Domain.Aggregates.Reservations.ValueObjects;
using Core.Domain.Aggregates.Users;

namespace Core.Domain.Services;

public static class ReservationServices
{
    public static (Reservation reservation, string? errorMessage) CreateReservation(
        User user, Copy copy, ReservationDate reservationDate 
    )
    {
        //check copy is available
        if (copy.OperationalStatus != OperationalStatus.Available)
            return (null!, "Copy is not available");
           
        //make copy reserved
        copy.MarkAsReserved();
         
        //create reservation
        var reservation = Reservation.Create(copy.Id, 
            user.Id, reservationDate);
        
        return (reservation, null);
    }

    public static string? Cancel(Reservation reservation, Copy copy)
    {
        reservation.Cancel();
        copy.MarkAsAvailable();

        return null;
    }
    
    public static string? Complete(Reservation reservation, Copy copy)
    {
        reservation.Complete();
        copy.MarkAsAvailable();

        return null;
    }
    
    public static string? Expire(Reservation reservation, Copy copy)
    {
        reservation.Expire();
        copy.MarkAsAvailable();

        return null;
    }
}