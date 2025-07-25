using Microsoft.Extensions.Logging;
using Orders.Application.Commands;
using Orders.Application.Exceptions;
using Orders.Domain.Entities;
using Orders.Domain.Repositories;
using Shared.Mediator;

namespace Orders.Application.Handlers;

public class UpdateOrderCommandHandler(
    IOrderRepository orderRepository,
    ILogger<UpdateOrderCommandHandler> logger) 
    : IRequestHandler<UpdateOrderCommand>
{
    public async Task<bool> Handle(UpdateOrderCommand request)
    {
        var orderToUpdate = await orderRepository.GetByIdAsync(request.Id);
        if(orderToUpdate == null)
            throw new OrderNotFoundException(nameof(Order), request.Id);
        
        await orderRepository.UpdateAsync(orderToUpdate);
        
        logger.LogInformation("Order {OrderId} has been updated.", orderToUpdate.Id);
        
        return true;
    }
}