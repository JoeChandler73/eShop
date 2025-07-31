using Catalog.Application.Queries;
using Catalog.Core.Model;
using Catalog.Core.Repositories;
using Shared.Mediator;

namespace Catalog.Application.Handlers;

public class GetProductByNameQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProductByNameQuery, IList<Product>>
{
    public async Task<IList<Product>> Handle(GetProductByNameQuery request)
    {
        var products = await productRepository.GetProductByName(request.Name);
        return products.ToList();
    }
}