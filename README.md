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

* ⚖️ **FluentValidation Integration**:

  * Input validation at application layer using expressive and composable validators

* 🎯 **FluentResults Pattern**:

  * Consistent result handling across application with `Success`, `Failure`, `NotFound`, and more

* 🔄 **Transactional Unit of Work**:

  * Ensures atomic operations across repositories

* 🧪 **Unit Tests**:

  * Test coverage for both domain logic and application services

* 📡 **RESTful API**:

  * Decoupled, cleanly designed controllers using MediatR

---

## 📁 Technologies & Patterns

* **C# 12**, **.NET 8**
* **EF Core 7+**
* **MediatR**
* **FluentValidation**
* **FluentResults**
* **SQL Server**
* **Clean Architecture** (Domain, Application, Infrastructure, Presentation)
* **DDD Building Blocks**: Aggregates, Value Objects, Domain Services, Events
* **Unit Testing**: xUnit, Moq

---
