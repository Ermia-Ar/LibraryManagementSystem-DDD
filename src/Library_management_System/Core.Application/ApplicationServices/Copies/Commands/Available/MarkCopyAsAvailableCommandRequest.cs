using Shared.Mediator.Command;

namespace Core.Application.ApplicationServices.Copies.Commands.Available;

public sealed record MarkCopyAsAvailableCommandRequest(
    long CopyId
    ) : ICommand;