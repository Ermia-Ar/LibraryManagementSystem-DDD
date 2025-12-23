using Core.Application.ApplicationServices.Users.Commands.Add;
using Core.Application.ApplicationServices.Users.Commands.AddLoan;
using Core.Application.ApplicationServices.Users.Commands.AddReservation;
using Core.Application.ApplicationServices.Users.Commands.Update;
using Core.Application.ApplicationServices.Users.Queries.GetLoans;
using Core.Application.ApplicationServices.Users.Queries.GetReservations;

namespace Library_management_System.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(ISender sender) : Controller
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<Response> Add(AddUserCommandRequest request,
        CancellationToken token = default)
    {
        return await _sender.Send(request, token);
    }

    [HttpPost("{id:long:required}/Loans")]
    public async Task<Response> AddLoan(long id,
        [FromBody] AddLoansCommandRequestDto model,
        CancellationToken token = default)
    {
        var request = AddLoansCommandRequest.Create(id, model);
        return await _sender.Send(request, token);
    }


    [HttpPost("{id:long:required}/Reservations")]
    public async Task<Response> AddReservation(long id,
        [FromBody] AddReservationCommandRequestDto model,
        CancellationToken token = default)
    {
        var request = AddReservationCommandRequest.Create(id, model);
        return await _sender.Send(request, token);
    }

    [HttpGet("{id:long:required}/Loans")]
    public async Task<Response<PaginatedResult<GetLoansForUserQueryResponse>>> GetLoans(long id,
        [FromQuery] GetLoansForUserQueryRequestDto model,
        CancellationToken token = default)
    {
        var request = GetLoansForUserQueryRequest.Create(id, model);
        return await _sender.Send(request, token);
    }

    [HttpGet("{id:long:required}/Reservations")]
    public async Task<Response<PaginatedResult<GetReservationsForUserQueryResponse>>> GetReservation(long id,
        [FromQuery] GetReservationsForUserQueryRequestDto model,
        CancellationToken token = default)
    {
        var request = GetReservationsForUserQueryRequest.Create(id, model);
        return await _sender.Send(request, token);
    }

    [HttpPut("{id:long:required}")]
    public async Task<Response> Put(long id,
        [FromBody] UpdateUserInfoCommandRequestDto model,
        CancellationToken token = default)
    {
        var request = UpdateUserInfoCommandRequest.Create(id, model);
        return await _sender.Send(request, token);
    }
}