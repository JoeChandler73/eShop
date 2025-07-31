namespace Catalog.Core.Model;

public record ProductBrand
{
    public string? Id { get; init; }
    
    public required string Name { get; init; }
}