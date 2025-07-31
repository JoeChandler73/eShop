using Catalog.Core.Model;
using Catalog.Core.Specs;
using Shared.Mediator;

namespace Catalog.Application.Queries;

public record GetAllProductsQuery(CatalogSpecParams CatalogSpecParams) : IRequest<Pagination<Product>>;