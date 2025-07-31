using System.Net;
using Basket.Application.Commands;
using Basket.Application.Events;
using Basket.Application.Queries;
using Basket.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Shared.Mediator;
using Shared.Messaging;

namespace Basket.Api.Controllers;

[Route("api/[controller]")]
public class BasketController(
    IMediator mediator,
    IMessageBus messageBus) : ControllerBase
{
    [HttpGet]
    [Route("[action]/{userName}", Name = "GetBasketByUserName")]
    [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ShoppingCart>> GetBasket(string userName)
    {
        var query = new GetBasketByUserNameQuery(userName);
        var basket = await mediator.Send(query);
        return Ok(basket);
    }

    [HttpPost("CreateBasket")]
    [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ShoppingCart>> UpdateBasket(
        [FromBody] CreateShoppingCartCommand createShoppingCartCommand)
    {
        var basket = await mediator.Send(createShoppingCartCommand);
        return Ok(basket);
    }

    [HttpDelete]
    [Route("[action]/{userName}", Name = "DeleteBasketByUserName")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<ShoppingCart>> DeleteBasket(string userName)
    {
        var command = new DeleteBasketByUserNameCommand(userName);
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpPost]
    [Route("[action]")]
    [ProducesResponseType((int)HttpStatusCode.Accepted)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Checkout([FromBody] BasketCheckout basketCheckout)
    {
        var query = new GetBasketByUserNameQuery(basketCheckout.UserName);
        var basket = await mediator.Send(query);
        
        if(basket == null)
            return BadRequest();

        var eventMessage = new BasketCheckoutEvent
        {
            UserName = basketCheckout.UserName,
            TotalPrice = basketCheckout.TotalPrice,
            FirstName = basketCheckout.FirstName,
            LastName = basketCheckout.LastName,
            EmailAddress = basketCheckout.EmailAddress,
            AddressLine = basketCheckout.AddressLine,
            Country = basketCheckout.Country,
            State = basketCheckout.State,
            ZipCode = basketCheckout.ZipCode,
            CardName = basketCheckout.CardName,
            CardNumber = basketCheckout.CardNumber,
            Expiration = basketCheckout.Expiration,
            Cvv = basketCheckout.Cvv,
            PaymentMethod = basketCheckout.PaymentMethod
        };
        
        await messageBus.Send(eventMessage);
        
        var deleteQuery = new DeleteBasketByUserNameCommand(basketCheckout.UserName);
        await mediator.Send(deleteQuery);
        return Accepted();
    }
}