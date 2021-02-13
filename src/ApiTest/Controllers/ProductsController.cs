namespace ApiTest.Controllers
{
    using Application.Features.Products.GetTrolleyTotalQueries;
    using Application.Features.Products.Queries;
    using Application.Users.Queries;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class ProductsController : BaseController
    {
        [HttpGet]
        [Route("")]
        [Route("user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetUserAsync() =>
         Ok(await Mediator.Send(new GetUserDetailsRequest()));

        [HttpGet("sort")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetOrderedProductListAsync([FromQuery] GetProductsRequest request) =>
         Ok(await Mediator.Send(request));

        [HttpPost("trolleytotal")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CalculateTrolleyTotalAsync([FromBody] GetTrolleyTotalRequest request) =>
         Ok(await Mediator.Send(request));
    }
}