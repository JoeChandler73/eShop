using Orders.Application.Responses;
using Shared.Mediator;

namespace Orders.Application.Queries;

public record GetOrderListQuery(string UserName) : IRequest<List<OrderResponse>>;