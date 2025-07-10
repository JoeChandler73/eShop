using Catalog.Application.Queries;
using Catalog.Core.Model;
using Catalog.Core.Repositories;
using Shared.Mediator;

namespace Catalog.Application.Handlers;

public class GetAllBrandsRequestHandler(IBrandRepository brandRepository) : IRequestHandler<GetAllBrandsQuery, IList<ProductBrand>>
{
    public async Task<IList<ProductBrand>> Handle(GetAllBrandsQuery request)
    {
        var brands = await brandRepository.GetAllBrands();
        return brands.ToList();
    }
}