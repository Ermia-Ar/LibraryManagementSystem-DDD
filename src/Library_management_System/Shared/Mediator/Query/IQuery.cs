namespace Shared.Mediator.Query;

public interface IQuery<TResponse> : IRequest<Response<TResponse>>
{
}
