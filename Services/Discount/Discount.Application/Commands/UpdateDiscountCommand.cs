using Discount.Domain.Model;
using Shared.Mediator;

namespace Discount.Application.Commands;

public class UpdateDiscountCommand : IRequest<Coupon>
{
    public int Id { get; set; }
    
    public string ProductName { get; set; }
    
    public string Description { get; set; }
    
    public int Amount { get; set; }
}