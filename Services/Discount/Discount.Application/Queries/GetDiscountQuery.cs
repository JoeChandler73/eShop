using Discount.Domain.Model;
using Shared.Mediator;

namespace Discount.Application.Queries;

public class GetDiscountQuery : IRequest<Coupon>
{
    public string ProductName { get; set; }

    public GetDiscountQuery(string productName)
    {
        ProductName = productName;
    }
}