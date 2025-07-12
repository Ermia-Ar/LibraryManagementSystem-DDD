using MediatR;
using Shared.Responses;

namespace Shared.Command;

public interface ICommandHandler<TRequest> : IRequestHandler<TRequest, Response>
	where TRequest : ICommand
{

}

public interface ICommandHandler<TRequest, TResponse> 
	: IRequestHandler<TRequest, Response<TResponse>> where TRequest : ICommand<TResponse>
{

}