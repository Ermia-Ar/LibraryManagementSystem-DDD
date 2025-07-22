namespace Core.Domain.Aggregates.Reservations.Enums;

public enum ReservationStatus
{
    Pending,
    Completed,    // اتمام‌یافته
    Cancelled,    // لغوشده
    Expired,      // منقضی‌شده
}
