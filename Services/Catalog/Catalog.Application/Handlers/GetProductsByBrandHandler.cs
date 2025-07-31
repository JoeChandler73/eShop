using Catalog.Application.Queries;
using Catalog.Core.Model;
using Catalog.Core.Repositories;
using Shared.Mediator;

namespace Catalog.Application.Handlers;

public class GetProductsByBrandHandler(IProductRepository productRepository) : IRequestHandler<GetProductsByBrandQuery, IList<Product>>
{
    public async Task<IList<Product>> Handle(GetProductsByBrandQuery request)
    {
        var products = await productRepository.GetProductsByBrand(request.BrandName);
        return products.ToList();
    }
}