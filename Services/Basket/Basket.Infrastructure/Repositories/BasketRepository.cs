using Basket.Domain.Model;
using Basket.Domain.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.Infrastructure.Repositories;

public class BasketRepository(
    IDistributedCache redisCache) : IBasketRepository
{
    public async Task<ShoppingCart?> GetBasket(string userName)
    {
        var json = await redisCache.GetStringAsync(userName);

        return string.IsNullOrEmpty(json) ? null : JsonConvert.DeserializeObject<ShoppingCart>(json);
    }

    public async Task<ShoppingCart?> UpdateBasket(ShoppingCart shoppingCart)
    {
        await redisCache.SetStringAsync(shoppingCart.UserName, JsonConvert.SerializeObject(shoppingCart));
        return await GetBasket(shoppingCart.UserName);
    }

    public async Task DeleteBasket(string userName)
    {
        await redisCache.RemoveAsync(userName);
    }
}