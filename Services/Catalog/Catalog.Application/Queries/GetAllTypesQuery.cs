using Catalog.Core.Model;
using Shared.Mediator;

namespace Catalog.Application.Queries;

public record GetAllTypesQuery : IRequest<IList<ProductType>>;