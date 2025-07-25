using Shared.Mediator;

namespace Orders.Application.Commands;

public class DeleteOrderCommand : IRequest
{
    public int Id { get; set; }
}