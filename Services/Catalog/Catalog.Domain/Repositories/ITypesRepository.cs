using Catalog.Core.Model;

namespace Catalog.Core.Repositories;

public interface ITypesRepository
{
    Task<IEnumerable<ProductType>> GetAllTypes();
}