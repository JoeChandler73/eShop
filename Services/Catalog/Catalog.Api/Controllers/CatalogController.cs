using System.Net;
using Catalog.Application.Queries;
using Catalog.Core.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CatalogController(
    IMediator _mediator,
    ILogger<CatalogController> _logger) : ControllerBase
{
    [HttpGet]
    [Route("GetAllBrands")]
    [ProducesResponseType(typeof(IList<ProductBrand>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IList<ProductBrand>>> GetAllBrands()
    {
        var query = new GetAllBrandsQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}