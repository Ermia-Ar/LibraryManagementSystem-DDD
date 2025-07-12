using MediatR;
using Shared.Responses;

namespace Shared.Query;

public interface IQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, Response<TResponse>>
	where TRequest : IQuery<TResponse>
{

}
