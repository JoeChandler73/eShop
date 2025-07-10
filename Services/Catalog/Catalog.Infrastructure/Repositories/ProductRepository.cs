using Catalog.Core.Model;
using Catalog.Core.Repositories;
using Catalog.Core.Specs;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories;

public class ProductRepository(ICatalogContext context) 
    : IProductRepository, IBrandRepository, ITypesRepository
{
    public async Task<Pagination<Product>> GetProducts(CatalogSpecParams catalogSpecParams)
    {
        var builder = Builders<ProductEntity>.Filter;
        var filter = builder.Empty;
        if (!string.IsNullOrWhiteSpace(catalogSpecParams.Search))
        {
            var searchFilter = builder.Regex(x => x.Name, new BsonRegularExpression(catalogSpecParams.Search));
            filter &= searchFilter;
        }
        if(!string.IsNullOrWhiteSpace(catalogSpecParams.BrandId))
        {
            var brandFilter = builder.Eq(x => x.Brands.Id, catalogSpecParams.BrandId);
            filter &= brandFilter;
        }
        if(!string.IsNullOrWhiteSpace(catalogSpecParams.TypeId))
        {
            var typeFilter = builder.Eq(x => x.Types.Id, catalogSpecParams.TypeId);
            filter &= typeFilter;
        }
        
        if (!string.IsNullOrWhiteSpace(catalogSpecParams.Sort))
        {
            var data = await DataFilter(catalogSpecParams, filter);
            
            return new Pagination<Product>
            {
                PageSize = catalogSpecParams.PageSize,
                PageIndex = catalogSpecParams.PageIndex,
                Data = data.Select(p => p.ToProduct()).ToList(),
                Count = await context.Products.CountDocumentsAsync(p => true) //TODO: Need to check while applying with UI
            };
        }
        
        var products = await context
            .Products
            .Find(filter)
            .Sort(Builders<ProductEntity>.Sort.Ascending("Name"))
            .Skip(catalogSpecParams.PageSize * (catalogSpecParams.PageIndex - 1))
            .Limit(catalogSpecParams.PageSize)
            .ToListAsync();
        
        return new Pagination<Product>
        {
            PageSize = catalogSpecParams.PageSize,
            PageIndex = catalogSpecParams.PageIndex,
            Data = products.Select(p => p.ToProduct()).ToList(),
            Count = await context.Products.CountDocumentsAsync(p => true)
        };
    }

    public async Task<Product> GetProduct(string id)
    {
        var product = await context
            .Products
            .Find(x => x.Id == id)
            .FirstOrDefaultAsync();
        
        return product.ToProduct();
    }

    public async Task<IEnumerable<Product>> GetProductByName(string name)
    {
        var filter = Builders<ProductEntity>.Filter.Eq(p => p.Name, name);
        var products = await context.Products.Find(filter).ToListAsync();
        return products.Select(p => p.ToProduct());
    }

    public async Task<IEnumerable<Product>> GetProductsByBrand(string name)
    {
        var filter = Builders<ProductEntity>.Filter.Eq(p => p.Brands.Name, name);
        var products = await context.Products.Find(filter).ToListAsync();
        return products.Select(p => p.ToProduct());
    }

    public async Task<IEnumerable<ProductBrand>> GetAllBrands()
    {
        var productBrands = await context
            .ProductBrands
            .Find(x => true)
            .ToListAsync();
        
        return productBrands.Select(b => b.ToProductBrand());
    }

    public async Task<IEnumerable<ProductType>> GetAllTypes()
    {
        var productTypes = await context
            .ProductTypes
            .Find(x => true)
            .ToListAsync();

        return productTypes.Select(t => t.ToProductType());
    }
    
    public async Task<Product> CreateProduct(Product product)
    {
        var productEntity = product.ToProductEntity();
        await context.Products.InsertOneAsync(productEntity);
        return product;
    }
    
    private async Task<IReadOnlyList<ProductEntity>> DataFilter(CatalogSpecParams catalogSpecParams, FilterDefinition<ProductEntity> filter)
    {
        switch (catalogSpecParams.Sort)
        {
            case "priceAsc":
                return await context
                    .Products
                    .Find(filter)
                    .Sort(Builders<ProductEntity>.Sort.Ascending("Price"))
                    .Skip(catalogSpecParams.PageSize * (catalogSpecParams.PageIndex - 1))
                    .Limit(catalogSpecParams.PageSize)
                    .ToListAsync();
            case "priceDesc":
                return await context
                    .Products
                    .Find(filter)
                    .Sort(Builders<ProductEntity>.Sort.Descending("Price"))
                    .Skip(catalogSpecParams.PageSize * (catalogSpecParams.PageIndex - 1))
                    .Limit(catalogSpecParams.PageSize)
                    .ToListAsync();
            default:
                return await context
                    .Products
                    .Find(filter)
                    .Sort(Builders<ProductEntity>.Sort.Ascending("Name"))
                    .Skip(catalogSpecParams.PageSize * (catalogSpecParams.PageIndex - 1))
                    .Limit(catalogSpecParams.PageSize)
                    .ToListAsync();
        }
    }
}