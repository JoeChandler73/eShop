using Microsoft.Extensions.Logging;
using Orders.Application.Commands;
using Orders.Application.Exceptions;
using Orders.Domain.Entities;
using Orders.Domain.Repositories;
using Shared.Mediator;

namespace Orders.Application.Handlers;

public class DeleteOrderCommandHandler(
    IOrderRepository orderRepository,
    ILogger<DeleteOrderCommandHandler> logger) 
    : IRequestHandler<DeleteOrderCommand>
{
    public async Task<bool> Handle(DeleteOrderCommand request)
    {
        var orderToDelete = await orderRepository.GetByIdAsync(request.Id);
        if (orderToDelete == null)
            throw new OrderNotFoundException(nameof(Order), request.Id);
        
        await orderRepository.DeleteAsync(orderToDelete);
        logger.LogInformation("Order {OrderId} has been deleted.", orderToDelete.Id);
        return true;
    }
}