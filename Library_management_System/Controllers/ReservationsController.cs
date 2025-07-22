    using Core.Application.ApplicationServices.Reservations.Commands.Cancel;
    using Core.Application.ApplicationServices.Reservations.Commands.Complete;
    using Core.Application.ApplicationServices.Reservations.Commands.Expire;
    using Core.Application.ApplicationServices.Reservations.Queries.GetById;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Shared.Responses;

    namespace Library_management_System.Controllers;


    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController(
        ISender sender
        ) : Controller
    {
        private readonly ISender _sender = sender;

        
        [HttpGet("{id:long:required}")]
        public async Task<Response<GetReservationByIdQueryResponse>> GetById(long id,
            CancellationToken token = default)
        {
            var request = new GetReservationByIdQueryRequest(id); 
            return await _sender.Send(request, token);
        }
        
        [HttpPatch("{id:long:required}/Cancel")]
        public async Task<Response> Cancel(long id,
            CancellationToken token = default)
        {
            var request = new CancelReservationCommandRequest(id);
            return await _sender.Send(request, token);
        }
        
        [HttpPatch("{id:long:required}/Complete")]
        public async Task<Response> Complete(long id,
            CancellationToken token = default)
        {
            var request = new CompleteReservationCommandRequest(id);
            return await _sender.Send(request, token);
        }
        
        [HttpPatch("{id:long:required}/Expire")]
        public async Task<Response> Expire(long id,
            CancellationToken token = default)
        {
            var request = new ExpireReservationCommandRequest(id);
            return await _sender.Send(request, token);
        }
        
    }