using MediatR;
using Shared.Responses;

namespace Shared.Mediator.Command;

public interface ICommandHandler<TRequest> : IRequestHandler<TRequest, Response>
	where TRequest : ICommand
{

}