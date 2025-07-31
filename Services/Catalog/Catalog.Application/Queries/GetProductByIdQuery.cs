using Catalog.Core.Model;
using Shared.Mediator;

namespace Catalog.Application.Queries;

public record GetProductByIdQuery(string Id): IRequest<Product>;