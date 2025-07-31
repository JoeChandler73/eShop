using Catalog.Application.Queries;
using Catalog.Core.Model;
using Catalog.Core.Repositories;
using Shared.Mediator;

namespace Catalog.Application.Handlers;

public class GetProductByIdQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProductByIdQuery, Product>
{
    public async Task<Product> Handle(GetProductByIdQuery request)
    {
        return await productRepository.GetProduct(request.Id);
    }
}