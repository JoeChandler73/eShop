using Catalog.Application.Queries;
using Catalog.Core.Model;
using Catalog.Core.Repositories;
using Shared.Mediator;

namespace Catalog.Application.Handlers;

public class GetAllTypesHandler(ITypesRepository typesRepository) : IRequestHandler<GetAllTypesQuery, IList<ProductType>>
{
    public async Task<IList<ProductType>> Handle(GetAllTypesQuery request)
    {
        var types = await typesRepository.GetAllTypes();
        return types.ToList();
    }
}