namespace Core.Domain.Filtering;

public sealed record  GetReservationFiltering(
    long? BookId,
    DateTime? ReservationDate,
    ReservationStatus? Status
 );