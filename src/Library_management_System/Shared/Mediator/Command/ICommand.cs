using MediatR;
using Shared.Responses;

namespace Shared.Mediator.Command;

public interface ICommand
    : IRequest<Response> 
{ }

