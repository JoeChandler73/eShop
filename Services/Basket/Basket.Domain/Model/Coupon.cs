namespace Basket.Domain.Model;

public class Coupon
{
    public int Id { get; set; }
    
    public string ProdcutName { get; set; }
    
    public string Description { get; set; }
    
    public int Amount { get; set; }
}