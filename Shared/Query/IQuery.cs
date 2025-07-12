using MediatR;
using Shared.Responses;

namespace Shared.Query;

public interface IQuery<TResponse> : IRequest<Response<TResponse>>
{
}
