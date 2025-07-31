namespace Basket.Domain.Model;

public record ShoppingCart
{
    public required string UserName { get; init; }

    public required List<ShoppingCartItem> Items { get; init; } = new();
}