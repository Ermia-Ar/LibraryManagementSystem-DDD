// Global using directives

global using System.Collections.Immutable;
global using System.Data;
global using Core.Domain.Aggregates.Books;
global using Core.Domain.Aggregates.Books.Repository;
global using Core.Domain.Aggregates.Copies;
global using Core.Domain.Aggregates.Copies.Repository;
global using Core.Domain.Aggregates.Loans;
global using Core.Domain.Aggregates.Loans.Repository;
global using Core.Domain.Aggregates.Reservations;
global using Core.Domain.Aggregates.Reservations.Repository;
global using Core.Domain.Aggregates.Users;
global using Core.Domain.Aggregates.Users.Repository;
global using Core.Domain.Filtering;
global using Dapper;
global using Infrastructure.Persistence.Context;
global using Microsoft.Data.SqlClient;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Shared.Helper;
global using Shared.Json;