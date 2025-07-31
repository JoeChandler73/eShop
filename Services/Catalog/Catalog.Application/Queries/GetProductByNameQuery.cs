using Catalog.Core.Model;
using Shared.Mediator;

namespace Catalog.Application.Queries;

public record GetProductByNameQuery(string Name) : IRequest<IList<Product>>;