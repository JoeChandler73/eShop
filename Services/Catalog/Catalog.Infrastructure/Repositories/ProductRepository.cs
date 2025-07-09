using Catalog.Core.Model;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Entities;
using MongoDB.Driver;
using Shared.Mapping;

namespace Catalog.Infrastructure.Repositories;

public class ProductRepository(ICatalogContext _context) 
    : IBrandRepository, ITypesRepository
{
    public async Task<IEnumerable<ProductBrand>> GetAllBrands()
    {
        var productBrands = await _context
            .ProductBrands
            .Find(x => true)
            .ToListAsync();
        
        return productBrands.Select(Mapper.Map<ProductBrandEntity, ProductBrand>);
    }

    public async Task<IEnumerable<ProductType>> GetAllTypes()
    {
        var productTypes = await _context
            .ProductTypes
            .Find(x => true)
            .ToListAsync();

        return productTypes.Select(Mapper.Map<ProductTypeEntity, ProductType>);
    }
}