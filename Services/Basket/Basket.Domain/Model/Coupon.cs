namespace Basket.Domain.Model;

public record Coupon
{
    public int? Id { get; set; }
    
    public required string ProductName { get; init; }
    
    public required string Description { get; init; }
    
    public required int Amount { get; init; }
}