using Core.Domain.Aggregates.Reservations.Enums;

namespace Core.Domain.Filtering;

public sealed record  GetReservationFiltering(
    long? BookId,
    DateTime? ReservationDate,
    ReservationStatus? Status
 );