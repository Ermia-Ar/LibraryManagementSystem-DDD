┌────────────────────────┐
│         User           │
├────────────────────────┤
│ + Id                   │
│ + Name (ValueObject)   │
│ + Email (ValueObject)  │
│ + PhoneNumber (VO)     │
│ + Address (VO)         │
│ + Sex (VO)             │
│ + CheckedOutIds[]      │
└────────┬───────────────┘
         │ 1
         │
         ▼
┌────────────────────────┐
│         Loan           │
├────────────────────────┤
│ + Id                   │
│ + CopyId               │
│ + UserId               │
│ + BorrowDate (VO)      │
│ + DueDate              │
│ + ReturnDate?          │
│ + FineAmount           │
└────────┬───────────────┘
         │ 1
         │
         ▼
┌────────────────────────┐
│         Copy           │
├────────────────────────┤
│ + Id                   │
│ + BookId               │
│ + OperationalStatus    │ (Available / Borrowed / Reserved / Decommissioned)
└────────┬───────────────┘
         │ *
         │
         ▼
┌────────────────────────┐
│         Book           │
├────────────────────────┤
│ + Id                   │
│ + Title                │
│ + Author               │
│ + Genre(s)             │
│ + ISBN                 │
└────────────────────────┘

┌────────────────────────┐
│      Reservation        │
├────────────────────────┤
│ + Id                   │
│ + UserId               │
│ + CopyId               │
│ + Status               │ (Active / Completed / Canceled)
└────────────────────────┘
