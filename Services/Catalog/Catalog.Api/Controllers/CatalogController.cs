using System.Net;
using Catalog.Application.Commands;
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
    [Route("[action]/{id}", Name = "GetProductById")]
    [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<Product>> GetProductById(string id)
    {
        var query = new GetProductByIdQuery(id);
        var result = await mediator.Send(query);
        return Ok(result);
    }
    
    [HttpGet]
    [Route("[action]/{productName}", Name = "GetProductByProductName")]
    [ProducesResponseType(typeof(IList<Product>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IList<Product>>> GetProductByProductName(string productName)
    {
        var query = new GetProductByNameQuery(productName);
        var result = await mediator.Send(query);
        return Ok(result);
    }
    
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

    [HttpGet]
    [Route("[action]/{brand}", Name = "GetProductsByBrandName")]
    [ProducesResponseType(typeof(IList<ProductType>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IList<ProductType>>> GetProductsByBrandName(string brand)
    {
        var query = new GetProductsByBrandQuery(brand);
        var result = await mediator.Send(query);
        return Ok(result);
    }
    
    [HttpPost]
    [Route( "CreateProduct")]
    [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<Product>> CreateProduct([FromBody] CreateProductCommand productCommand)
    {
        var result = await mediator.Send(productCommand);
        return Ok(result);
    }
}

