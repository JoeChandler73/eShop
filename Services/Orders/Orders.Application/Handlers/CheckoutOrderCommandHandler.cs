using Microsoft.Extensions.Logging;
using Orders.Application.Commands;
using Orders.Domain.Entities;
using Orders.Domain.Repositories;
using Shared.Mediator;

namespace Orders.Application.Handlers;

public class CheckoutOrderCommandHandler(
    IOrderRepository orderRepository,
    ILogger<CheckoutOrderCommandHandler> logger) 
    : IRequestHandler<CheckoutOrderCommand, int>
{
    public async Task<int> Handle(CheckoutOrderCommand request)
    {
        var orderEntry = new Order
        {
            UserName = request.UserName,
            TotalPrice = request.TotalPrice,
            FirstName = request.FirstName,
            LastName = request.LastName,
            EmailAddress = request.EmailAddress,
            AddressLine = request.AddressLine,
            Country = request.Country,
            State = request.State,
            ZipCode = request.ZipCode,
            CardName = request.CardName,
            CardNumber = request.CardNumber,
            Expiration = request.Expiration,
            Cvv = request.Cvv,
            PaymentMethod = request.PaymentMethod
        };

        var generatedOrder = await orderRepository.AddAsync(orderEntry);
        logger.LogInformation("Order {GeneratedOrder} successfully created}.", generatedOrder);
        return generatedOrder.Id ?? 0;
    }
}