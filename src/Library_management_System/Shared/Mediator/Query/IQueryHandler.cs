namespace Shared.Mediator.Query;

public interface IQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, Response<TResponse>>
	where TRequest : IQuery<TResponse>
{

}
