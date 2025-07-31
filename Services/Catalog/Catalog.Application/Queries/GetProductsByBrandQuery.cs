using Catalog.Core.Model;
using Shared.Mediator;

namespace Catalog.Application.Queries;

public record GetProductsByBrandQuery(string BrandName) : IRequest<IList<Product>>;