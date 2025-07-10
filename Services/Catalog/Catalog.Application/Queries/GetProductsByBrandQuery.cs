using Catalog.Core.Model;
using Shared.Mediator;

namespace Catalog.Application.Queries;

public class GetProductsByBrandQuery : IRequest<IList<Product>>
{
    public GetProductsByBrandQuery(string brandName)
    {
        BrandName = brandName;
    }

    public string BrandName { get; set; }
}