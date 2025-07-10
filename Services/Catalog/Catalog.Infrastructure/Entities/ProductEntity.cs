using Catalog.Core.Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Infrastructure.Entities;

public class ProductEntity : BaseEntity
{
    [BsonElement("Name")]
    public string Name { get; set; }
    
    public string Summary { get; set; }
    
    public string Description { get; set; }
    
    public string ImageFile { get; set; }
    
    public ProductBrandEntity Brands { get; set; }
    
    public ProductTypeEntity Types { get; set; }
    
    [BsonRepresentation(BsonType.Decimal128)]
    public decimal Price { get; set; }
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
            Id = product.Id,
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