# 📚 Library Management System (DDD Approach)

A modular and extensible Library Management System built using **Clean Architecture** and **Domain-Driven Design** principles.

---

## 🔍 Key Features

* 📚 **Rich Domain Layers**:

  * `Book`, `Copy`, `Loan`, `Reservation`, and `User` as separate domain aggregates

* ✅ **CQRS Pattern**:
  
  * Clear separation of command and query responsibilities
    
* 🧩 **Domain-Driven Design**: 

  * Use of **Value Objects**, **Aggregates**, **Domain Services**, and **Repositories**

* 💡 **Domain & Integration Events**:

  * Events triggered on domain changes (e.g., `LoanReturnedEvent`, `ReservationCompletedEvent`)

* ⚖️ **FluentValidation Integration**
  

* 🎯 **FluentResults Pattern**
  

* 🔄 **Transactional Unit of Work**
  

* 📡 **RESTful API**

---

## 📁 Technologies & Patterns

* **C# 12**, **.NET 8**
* **EF Core 7+**
* **MediatR**
* **FluentValidation**
* **SQL Server**
* **Clean Architecture** (Domain, Application, Infrastructure, Presentation)
* **DDD Building Blocks**: Aggregates, Value Objects, Domain Services, Events
---

## 💼 What You Can Do

 This system provides full capabilities for managing a library lifecycle:

* 🔎 **Search & View Books**:

 * Browse available books and their metadata.

* 🆕 **Add New Books & Copies**:

 * Admins can register books and physical/digital copies.

* 📥 **Loan Management**:

 * Users can borrow available copies.

 * Track loan due dates and return borrowed items.

 * Automatically calculate fines for late returns.

* 📌 **Reservations**:

 * Reserve a book if all copies are currently borrowed.

 * Cancel or fulfill reservations.

* 👥 **User Management**:

 * Create and manage users and their loan history.

*🔄 **Returns & Renewals**:

 * Return borrowed books and update copy status.

 * (Planned) Renew borrowed copies before due date.

*🧠 **Event Handling**:

 * Domain and integration events trigger logic like:

 * Changing copy availability after return.

 * Completing reservations on successful borrow.

 * Sending notifications (future enhancement).
