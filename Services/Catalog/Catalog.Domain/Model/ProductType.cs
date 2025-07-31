namespace Catalog.Core.Model;

public record ProductType
{
    public string? Id { get; init; }
    
    public required string Name { get; init; }
}