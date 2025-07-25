using Orders.Application.Queries;
using Orders.Application.Resposnes;
using Orders.Domain.Repositories;
using Shared.Mediator;

namespace Orders.Application.Handlers;

public class GetOrderListQueryHandler(IOrderRepository orderRepository) : IRequestHandler<GetOrderListQuery, List<OrderResponse>>
{
    public async Task<List<OrderResponse>> Handle(GetOrderListQuery request)
    {
        var orderList = await orderRepository.GetOrdersByUserName(request.UserName);

        return orderList
            .Select(x =>
                new OrderResponse
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    TotalPrice = x.TotalPrice,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    EmailAddress = x.EmailAddress,
                    AddressLine = x.AddressLine,
                    Country = x.Country,
                    State = x.State,
                    ZipCode = x.ZipCode,
                    CardName = x.CardName,
                    CardNumber = x.CardNumber,
                    Expiration = x.Expiration,
                    Cvv = x.Cvv,
                    PaymentMethod = x.PaymentMethod
                })
            .ToList();
    }
}