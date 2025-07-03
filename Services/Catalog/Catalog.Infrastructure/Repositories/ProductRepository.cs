using AutoMapper;
using Catalog.Core.Model;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories;

public class ProductRepository(
    ICatalogContext _context,
    IMapper _mapper) : IBrandRepository
{
    public async Task<IEnumerable<ProductBrand>> GetAllBrands()
    {
        var productBrands = await _context
            .ProductBrands
            .Find(x => true)
            .ToListAsync();
        
        return productBrands.Select(_mapper.Map<ProductBrand>);
    }
}