namespace Application.Features.Products.GetTrolleyTotalQueries
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Interfaces;
    using Common.Models;
    using MediatR;

    public class
        GetTrolleyTotalQueryHandler : IRequestHandler<GetTrolleyTotalRequest,
            GetTrolleyTotalResponse>
    {
        private readonly IProductService _productService;


        public GetTrolleyTotalQueryHandler(IProductService productService)
        {
            _productService = productService;
        }


        public async Task<GetTrolleyTotalResponse> Handle(GetTrolleyTotalRequest request,
            CancellationToken cancellationToken)
        {
            var totalAmount = await _productService.GetTrollyTotalAsync(new TrolleyTotalRequest
            {
                Products = request.Products,
                Quantities = request.Quantities,
                Specials = request.Specials
            });
            var response = new GetTrolleyTotalResponse {TotalAmount = totalAmount};
            return await Task.FromResult(response);
        }
    }
}