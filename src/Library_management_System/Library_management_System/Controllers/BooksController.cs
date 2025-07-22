using Core.Application.ApplicationServices.Books.Commands.Add;
using Core.Application.ApplicationServices.Books.Commands.AddCopy;
using Core.Application.ApplicationServices.Books.Commands.AddGenres;
using Core.Application.ApplicationServices.Books.Commands.Remove;
using Core.Application.ApplicationServices.Books.Commands.RemoveGenre;
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
		CancellationToken token = default)
	{
		var result = await _sender.Send(request, token);
		return result;
	}

	
	[HttpPost("{id:long:required}/Copies")]
	public async Task<Response> AddCopy(long id,
		[FromBody] AddCopyCommandRequestDto model,
		CancellationToken token = default)
	{
		var request = AddCopyCommandRequest.Create(id, model);
		return await _sender.Send(request, token);
	}
	
	
	[HttpPatch("{id:long:required}/AddGenres")]
	public async Task<Response> AddGenre(long id,
		[FromBody] AddGenresCommandRequestDto model,
		CancellationToken token = default)
	{
		var request = AddGenresCommandRequest.Create(id, model);
		return await _sender.Send(request, token);
	}
	
	[HttpPatch("{id:long:required}/RemoveGenre")]
	public async Task<Response> RemoveGenre(long id,
		[FromBody] RemoveGenreCommandRequestDto model,
		CancellationToken token = default)
	{
		var request = RemoveGenreCommandRequest.Create(id, model);
		return await _sender.Send(request, token);
	}
	
	[HttpDelete("{id:long:required}")]
	public async Task<Response> Remove(long id,
		CancellationToken token = default)
	{
		var request = new RemoveBookCommandRequest(id);
		return await _sender.Send(request, token);
	}
	
}

