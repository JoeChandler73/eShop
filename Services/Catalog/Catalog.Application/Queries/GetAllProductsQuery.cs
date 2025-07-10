using Catalog.Core.Model;
using Catalog.Core.Specs;
using Shared.Mediator;

namespace Catalog.Application.Queries;

public class GetAllProductsQuery(CatalogSpecParams catalogSpecParams) : IRequest<Pagination<Product>>
{
    public CatalogSpecParams CatalogSpecParams { get; set; } = catalogSpecParams;
}