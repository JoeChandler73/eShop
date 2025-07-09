namespace Catalog.Core.Model;

public class Product
{
    public string Name { get; set; }
    
    public string Summary { get; set; }
    
    public string Description { get; set; }
    
    public string ImageFile { get; set; }
    
    public decimal Price { get; set; }
    
    public ProductBrand Brands { get; set; }
    
    public ProductType Types { get; set; }
}