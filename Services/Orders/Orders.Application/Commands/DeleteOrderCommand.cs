using Shared.Mediator;

namespace Orders.Application.Commands;

public record DeleteOrderCommand(int Id) : IRequest;