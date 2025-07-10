using Catalog.Core.Model;
using Catalog.Core.Specs;

namespace Catalog.Core.Repositories;

public interface IProductRepository
{
    Task<Pagination<Product>> GetProducts(CatalogSpecParams catalogSpecParams);
    
    Task<Product> GetProduct(string id);
    
    Task<IEnumerable<Product>> GetProductByName(string name);
    
    Task<IEnumerable<Product>> GetProductsByBrand(string name);
    
    Task<Product> CreateProduct(Product product);
}