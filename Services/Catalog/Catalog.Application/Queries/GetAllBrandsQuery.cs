using Catalog.Core.Model;
using Shared.Mediator;

namespace Catalog.Application.Queries;

public class GetAllBrandsQuery : IRequest<IList<ProductBrand>>
{
}