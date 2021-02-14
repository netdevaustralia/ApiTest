namespace ShoppingCart.Api.Controllers
{
    using System.Threading.Tasks;
    using Application.Features.Products.GetProductsQueries;
    using Application.Features.Products.GetTrolleyTotalQueries;
    using Application.Features.Products.GetUserDetailsQueries;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : BaseController
    {
        [HttpGet]
        [Route("")]
        [Route("user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetUserAsync()
        {
            return Ok(await Mediator.Send(new GetUserDetailsRequest()));
        }


        [HttpGet("sort")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetOrderedProductListAsync(
            [FromQuery] GetProductsRequest request)
        {
            return Ok(await Mediator.Send(request));
        }


        [HttpPost("trolleytotal")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CalculateTrolleyTotalAsync(
            [FromBody] GetTrolleyTotalRequest request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}