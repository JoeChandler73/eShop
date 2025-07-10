using System.Net;
using Catalog.Application.Queries;
using Catalog.Core.Model;
using Catalog.Core.Specs;
using Microsoft.AspNetCore.Mvc;
using Shared.Mediator;

namespace Catalog.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CatalogController(
    IMediator mediator,
    ILogger<CatalogController> logger) : ControllerBase
{
    [HttpGet]
    [Route("GetAllProducts")]
    [ProducesResponseType(typeof(IList<Product>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IList<Product>>> GetAllProducts([FromQuery] CatalogSpecParams catalogSpecParams)
    {
        try
        {
            var query = new GetAllProductsQuery(catalogSpecParams);
            var result = await mediator.Send(query);
            logger.LogInformation("All products retrieved");
            return Ok(result);
        }
        catch (Exception e)
        {
            logger.LogError("Error Getting All Products; {Exception}", e);
            throw;
        }
    }
    
    [HttpGet]
    [Route("GetAllBrands")]
    [ProducesResponseType(typeof(IList<ProductBrand>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IList<ProductBrand>>> GetAllBrands()
    {
        var query = new GetAllBrandsQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }
    
    [HttpGet]
    [Route("GetAllTypes")]
    [ProducesResponseType(typeof(IList<ProductType>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IList<ProductType>>> GetAllTypes()
    {
        var query = new GetAllTypesQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }
}

