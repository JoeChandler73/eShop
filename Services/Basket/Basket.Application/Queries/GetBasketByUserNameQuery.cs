using Basket.Domain.Model;
using Shared.Mediator;

namespace Basket.Application.Queries;

public class GetBasketByUserNameQuery : IRequest<ShoppingCart>
{
    public string UserName { get; set; }

    public GetBasketByUserNameQuery(string userName)
    {
        UserName = userName;
    }
}