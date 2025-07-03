using AutoMapper;
using Catalog.Core.Model;
using Catalog.Infrastructure.Entities;

namespace Catalog.Infrastructure.Mappers;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<ProductBrandEntity, ProductBrand>();
    }
}