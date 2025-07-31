using Catalog.Application.Queries;
using Catalog.Core.Model;
using Catalog.Core.Repositories;
using Catalog.Core.Specs;
using Microsoft.Extensions.Logging;
using Shared.Mediator;

namespace Catalog.Application.Handlers;

public class GetAllProductsHandler(
    IProductRepository productRepository,
    ILogger<GetAllProductsHandler> logger) 
    : IRequestHandler<GetAllProductsQuery, Pagination<Product>>
{
    public async Task<Pagination<Product>> Handle(GetAllProductsQuery request)
    {
        var products = await productRepository.GetProducts(request.CatalogSpecParams);
        logger.LogDebug("Received Products Total Count: {products}", products.Count);
        return products;
    }
}