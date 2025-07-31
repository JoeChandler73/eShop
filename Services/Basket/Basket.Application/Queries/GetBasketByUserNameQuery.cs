using Basket.Domain.Model;
using Shared.Mediator;

namespace Basket.Application.Queries;

public record GetBasketByUserNameQuery(string UserName) : IRequest<ShoppingCart?>;