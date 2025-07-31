using Catalog.Core.Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Infrastructure.Entities;

public record ProductEntity : BaseEntity
{
    [BsonElement("Name")]
    public required string Name { get; init; }
    
    public required string Summary { get; init; }
    
    public required string Description { get; init; }
    
    public required string ImageFile { get; init; }
    
    public required ProductBrandEntity Brands { get; init; }
    
    public required ProductTypeEntity Types { get; init; }
    
    [BsonRepresentation(BsonType.Decimal128)]
    public decimal Price { get; init; }
}

public static class ProducEntityExtensions
{
    public static Product ToProduct(this ProductEntity entity)
    {
        return new Product
        {
            Id = entity.Id,
            Name = entity.Name,
            Summary = entity.Summary,
            Description = entity.Description,
            ImageFile = entity.ImageFile,
            Price = entity.Price,
            Brand = entity.Brands.ToProductBrand(),
            Type = entity.Types.ToProductType()
        };
    }

    public static ProductEntity ToProductEntity(this Product product)
    {
        return new ProductEntity
        {
            Id = string.IsNullOrWhiteSpace(product.Id) ? ObjectId.GenerateNewId().ToString() : product.Id,
            Name = product.Name,
            Summary = product.Summary,
            Description = product.Description,
            ImageFile = product.ImageFile,
            Price = product.Price,
            Brands = product.Brand.ToProductBrandEntity(),
            Types = product.Type.ToProductTypeEntity()
        };
    }
}