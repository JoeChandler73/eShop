using Catalog.Application.Queries;
using Catalog.Core.Model;
using Catalog.Core.Repositories;
using Shared.Mediator;

namespace Catalog.Application.Handlers;

public class GetAllTypesHandler(ITypesRepository _typesRepository) : IRequestHandler<GetAllTypesQuery, IList<ProductType>>
{
    public async Task<IList<ProductType>> Handle(GetAllTypesQuery request)
    {
        var types = await _typesRepository.GetAllTypes();
        return types.ToList();
    }
}