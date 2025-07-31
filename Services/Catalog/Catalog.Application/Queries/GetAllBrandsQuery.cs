using Catalog.Core.Model;
using Shared.Mediator;

namespace Catalog.Application.Queries;

public record GetAllBrandsQuery : IRequest<IList<ProductBrand>>;