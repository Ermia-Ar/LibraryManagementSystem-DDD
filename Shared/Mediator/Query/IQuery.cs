using MediatR;
using Shared.Responses;

namespace Shared.Mediator.Query;

public interface IQuery<TResponse> : IRequest<Response<TResponse>>
{
}
