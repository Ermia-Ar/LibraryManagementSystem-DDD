namespace Library_management_System.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoansController(
    ISender sender
) : Controller
{
    private readonly ISender _sender = sender;

    [HttpPatch("{id:long:required}/Return")]
    public async Task<Response> Return(long id,
        CancellationToken token = default)
    {
        var request = new ReturnLoanCommandRequest(id);
        return await _sender.Send(request, token);
    }

    [HttpGet("{id:long:required}")]
    public async Task<Response<GetLoanByIdQueryResponse>> GetById(long id,
        CancellationToken token = default)
    {
        var request = new GetLoanByIdQueryRequest(id);
        return await _sender.Send(request, token);
    }
}