namespace Catalog.Core.Model;

public record Product
{
    public string? Id { get; init; }
    
    public required string Name { get; init; }
    
    public required string Summary { get; init; }
    
    public required string Description { get; init; }
    
    public required string ImageFile { get; init; }
    
    public required decimal Price { get; init; }
    
    public required ProductBrand Brand { get; init; }
    
    public required ProductType Type { get; init; }
}