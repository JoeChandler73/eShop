namespace Basket.Domain.Model;

public record ShoppingCartItem
{
    public required string ProductId { get; init; }
    public required string ProductName { get; init; }
    
    public required int Quantity { get; init; }
    
    public required decimal Price { get; set; }
    
    public required string ImageFile { get; init; }
}