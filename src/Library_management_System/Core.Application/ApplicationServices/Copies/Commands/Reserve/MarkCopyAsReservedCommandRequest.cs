using Shared.Mediator.Command;

namespace Core.Application.ApplicationServices.Copies.Commands.Reserve;

public record MarkCopyAsReservedCommandRequest(
    long CopyId
) : ICommand;