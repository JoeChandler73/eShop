using Catalog.Application.Commands;
using Catalog.Core.Model;
using Catalog.Core.Repositories;
using Shared.Mediator;

namespace Catalog.Application.Handlers;

public class CreateProductHandler(IProductRepository productRepository) : IRequestHandler<CreateProductCommand, Product>
{
    public async Task<Product> Handle(CreateProductCommand request)
    {
        return await productRepository.CreateProduct(request.ToProduct());
    }
}