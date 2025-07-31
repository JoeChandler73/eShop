using Basket.Domain.Model;
using Basket.Domain.Services;
using Discount.Grpc.Protos;

namespace Basket.Infrastructure.Services;

public class DiscountService(DiscountProtoService.DiscountProtoServiceClient client) : IDiscountService
{
    public async Task<Coupon> GetDiscount(string productName)
    {
        var discountRequest = new GetDiscountRequest
        {
            ProductName = productName
        };
        
        var couponModel = await client.GetDiscountAsync(discountRequest);

        return new Coupon
        {
            Id = couponModel.Id,
            ProductName = couponModel.ProductName,
            Description = couponModel.Description,
            Amount = couponModel.Amount
        };
    }
}