using Application.Core.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace ApiTest.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(IProductManager productManager)
        {
            ProductManager = productManager;
        }

        public IProductManager ProductManager { get; }

        [HttpGet("user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetUserAsync()
        {
            return Ok(await ProductManager.GetUserAsync());
        }

    }
}
