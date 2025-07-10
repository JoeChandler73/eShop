using Catalog.Core.Model;
using Shared.Mediator;

namespace Catalog.Application.Queries;

public class GetProductByNameQuery : IRequest<IList<Product>>
{
    public string Name { get; set; }

    public GetProductByNameQuery(string name)
    {
        Name = name;
    }
}