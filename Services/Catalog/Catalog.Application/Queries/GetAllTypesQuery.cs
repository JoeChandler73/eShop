using Catalog.Core.Model;
using Shared.Mediator;

namespace Catalog.Application.Queries;

public class GetAllTypesQuery : IRequest<IList<ProductType>>
{
}