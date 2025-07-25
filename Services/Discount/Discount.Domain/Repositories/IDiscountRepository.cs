using Discount.Domain.Model;

namespace Discount.Domain.Repositories;

public interface IDiscountRepository
{
    Task<Coupon> GetDiscount(string productName);
    
    Task<bool> CreateDiscount(Coupon coupon);
    
    Task<bool> UpdateDiscount(Coupon coupon);
    
    Task<bool> DeleteDiscount(string productName);
}