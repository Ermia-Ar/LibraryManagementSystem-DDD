using Core.Application.ApplicationServices.Books.Commands.Add;
using Core.Application.ApplicationServices.Copies.Queries.GetAvailableCopies;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Responses;

namespace Library_management_System.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController(ISender sender) : Controller
{
	private readonly ISender _sender = sender;

	[HttpPost]
	public async Task<Response> Add(AddBookCommandRequest request,
		CancellationToken token)
	{
		var result = await _sender.Send(request, token);
		return result;
	}

	[HttpGet]
	public async Task<Response> GetAll(GetAvailableCopiesDto model,
		CancellationToken token)
	{
		var request = GetAvailableCopiesQueryRequest.Create(model);
		
		return await _sender.Send(request, token);
	}
}

