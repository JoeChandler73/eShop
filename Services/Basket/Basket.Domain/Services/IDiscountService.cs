using Basket.Domain.Model;

namespace Basket.Domain.Services;

public interface IDiscountService
{
    Task<Coupon> GetDiscount(string productName);
}