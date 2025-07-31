using Catalog.Core.Model;
using Shared.Mediator;

namespace Catalog.Application.Commands;

public record CreateProductCommand : IRequest<Product>
{
    public required string Name { get; init; }
    public required string Summary { get; init; }
    public required string Description { get; init; }
    public required string ImageFile { get; init; }
    public required decimal Price { get; init; }
    public required ProductBrand Brand { get; init; }
    public required ProductType Type { get; init; }
}

public static class CreateProductCommandExtensions
{
    public static Product ToProduct(this CreateProductCommand command) =>
        new Product
        {
            Name = command.Name,
            Summary = command.Summary,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price,
            Brand = command.Brand,
            Type = command.Type
        };
}