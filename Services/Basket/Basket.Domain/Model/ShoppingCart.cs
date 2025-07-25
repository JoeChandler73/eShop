namespace Basket.Domain.Model;

public class ShoppingCart
{
    public string UserName { get; set; }

    public List<ShoppingCartItem> Items { get; set; } = new();
    
    public ShoppingCart()
    {
        
    }

    public ShoppingCart(string userName)
    {
        UserName = userName;
    }
}