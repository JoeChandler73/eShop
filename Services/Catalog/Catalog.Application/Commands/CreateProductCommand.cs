using Catalog.Core.Model;
using Shared.Mediator;

namespace Catalog.Application.Commands;

public class CreateProductCommand : IRequest<Product>
{
    public string Name { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public string ImageFile { get; set; }
    public decimal Price { get; set; }
    
    public ProductBrand Brand { get; set; }
    
    public ProductType Type { get; set; }
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