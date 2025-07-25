using Orders.Application.Resposnes;
using Shared.Mediator;

namespace Orders.Application.Queries;

public class GetOrderListQuery : IRequest<List<OrderResponse>>
{
    public string UserName { get; set; }

    public GetOrderListQuery(string userName)
    {
        UserName = userName;
    }
}