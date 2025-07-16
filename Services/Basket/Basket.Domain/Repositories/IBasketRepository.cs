using Basket.Domain.Model;

namespace Basket.Domain.Repositories;

public interface IBasketRepository
{
    Task<ShoppingCart> GetBasket(string userName);
    
    Task<ShoppingCart> UpdateBasket(ShoppingCart shoppingCart);
    
    Task DeleteBasket(string userName);
}