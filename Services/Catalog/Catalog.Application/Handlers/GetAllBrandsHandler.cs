using Catalog.Application.Queries;
using Catalog.Core.Model;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class GetAllBrandsHandler(IBrandRepository _brandRepository) : IRequestHandler<GetAllBrandsQuery, IList<ProductBrand>>
{
    public async Task<IList<ProductBrand>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
    {
        var brands = await _brandRepository.GetAllBrands();
        return brands.ToList();
    }
}