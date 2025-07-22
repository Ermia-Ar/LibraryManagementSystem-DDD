using Shared.Mediator.Command;

namespace Core.Application.ApplicationServices.Copies.Commands.Decommissioned;

public sealed record MarkCopyAsDecommissionedCommandRequest(
    long CopyId
) : ICommand;