using Core.Application.ApplicationServices.Books.Commands.AddCopy;
using Core.Application.ApplicationServices.Copies.Commands.Decommissioned;
using Core.Application.ApplicationServices.Copies.Commands.Remove;
using Core.Application.ApplicationServices.Copies.Commands.UpdatePhysicalCondition;
using Core.Application.ApplicationServices.Copies.Commands.UpdatePrice;
using Core.Application.ApplicationServices.Copies.Queries.GetAvailable;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Helper;
using Shared.Responses;

namespace Library_management_System.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CopiesController(ISender sender) : Controller
{
    private readonly ISender _sender = sender;
    
    [HttpGet]
    public async Task<Response<PaginatedResult<GetAvailableCopiesQueryResponse>>> GetAll(
        [FromQuery] GetAvailableCopiesDto model,
        CancellationToken token)
    {
        var request = GetAvailableCopiesQueryRequest.Create(model);
		
        return await _sender.Send(request, token);
    }

    [HttpPatch("{id:long:required}/Decommission")]
    public async Task<Response> Decommission(long id,
        CancellationToken token)
    {
        var request = new MarkCopyAsDecommissionedCommandRequest(id);
        return await _sender.Send(request, token);
    }

    [HttpPatch("{id:long:required}/Price")]
    public async Task<Response> Price(long id,
        [FromBody] UpdatePriceCommandRequestDto model,
        CancellationToken token = default)
    {
        var request = UpdatePriceCommandRequest.Create(id, model);
        return await _sender.Send(request, token);
    }

    [HttpPatch("{id:long:required}/PhysicalCondition")]
    public async Task<Response> PhysicalCondition(long id,
        [FromBody] UpdatePhysicalConditionCommandRequestDto model,
        CancellationToken token = default)
    {
        var request = UpdatePhysicalConditionCommandRequest.Create(id, model);
        return await _sender.Send(request, token);
    }

    [HttpDelete("{id:long:required}")]
    public async Task<Response> Remove(long id,
        CancellationToken token = default)
    {
        var request = new RemoveCopyCommandRequest(id);
        return await _sender.Send(request, token);
    }
}