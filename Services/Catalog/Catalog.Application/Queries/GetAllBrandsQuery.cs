using Catalog.Core.Model;
using MediatR;

namespace Catalog.Application.Queries;

public class GetAllBrandsQuery : IRequest<IList<ProductBrand>>
{
    
}