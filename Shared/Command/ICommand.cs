using MediatR;
using Shared.Responses;

namespace Shared.Command;

public interface ICommand
    : IRequest<Response> 
{ }



public interface ICommand<TResponse>
    : IRequest<Response<TResponse>> { }
