namespace Core.Domain.Aggregates.Copies.Enums;

public enum OperationalStatus
{
    Available,      // در دسترس
    Borrowed,       // قرض گرفته‌شده
    Reserved,       // رزرو شده
    Decommissioned  // از رده خارج‌شده
}