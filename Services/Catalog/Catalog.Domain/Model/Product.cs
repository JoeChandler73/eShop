namespace Catalog.Core.Model;

public class Product
{
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public string Summary { get; set; }
    
    public string Description { get; set; }
    
    public string ImageFile { get; set; }
    
    public decimal Price { get; set; }
    
    public ProductBrand Brand { get; set; }
    
    public ProductType Type { get; set; }
}