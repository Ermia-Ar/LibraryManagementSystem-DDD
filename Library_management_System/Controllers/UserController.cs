using Core.Application.ApplicationServices.Users.Commands.Add;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Responses;

namespace Library_management_System.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(ISender sender) : Controller
{
    private readonly ISender _sender = sender;
    
    [HttpPost]
    public async Task<Response> Add(AddUserCommandRequest request,
        CancellationToken token)
    {
        var result = await _sender.Send(request, token);
        
        return result;
    }
}