// Global using directives

global using Core.Application.ApplicationServices.Books.Commands.Add;
global using Core.Application.ApplicationServices.Books.Commands.AddCopy;
global using Core.Application.ApplicationServices.Books.Commands.AddGenres;
global using Core.Application.ApplicationServices.Books.Commands.Remove;
global using Core.Application.ApplicationServices.Books.Commands.RemoveGenre;
global using Core.Application.ApplicationServices.Copies.Commands.Decommissioned;
global using Core.Application.ApplicationServices.Copies.Commands.Remove;
global using Core.Application.ApplicationServices.Copies.Commands.UpdatePhysicalCondition;
global using Core.Application.ApplicationServices.Copies.Commands.UpdatePrice;
global using Core.Application.ApplicationServices.Copies.Queries.GetAvailable;
global using Core.Application.ApplicationServices.Loans.Commands.Return;
global using Core.Application.ApplicationServices.Loans.Queries.GetById;
global using Core.Application.ApplicationServices.Reservations.Commands.Cancel;
global using Core.Application.ApplicationServices.Reservations.Commands.Complete;
global using Core.Application.ApplicationServices.Reservations.Commands.Expire;
global using Core.Application.ApplicationServices.Reservations.Queries.GetById;
global using MediatR;
global using Microsoft.AspNetCore.Mvc;
global using Shared.Helper;
global using Shared.Responses;