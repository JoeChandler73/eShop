using Catalog.Core.Model;
using Shared.Mediator;

namespace Catalog.Application.Queries;

public class GetProductByIdQuery: IRequest<Product>
{
    public string Id { get; set; }

    public GetProductByIdQuery(string id)
    {
        Id = id;
    }
}