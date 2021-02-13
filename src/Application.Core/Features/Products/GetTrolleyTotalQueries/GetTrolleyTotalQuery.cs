namespace Application.Features.Products.GetTrolleyTotalQueries
{
    using Application.Services;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetTrolleyTotalQueryHandler : IRequestHandler<GetTrolleyTotalRequest, GetTrolleyTotalResponse>
    {
        private readonly IProductService _productService;

        public GetTrolleyTotalQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<GetTrolleyTotalResponse> Handle(GetTrolleyTotalRequest request, CancellationToken cancellationToken)
        {
            var totalAmount = await _productService.GetTrollyTotalAsync(new Common.Models.TrolleyTotalRequest
            {
                Products = request.Products,
                Quantities = request.Quantities,
                Specials = request.Specials
            });
            var response = new GetTrolleyTotalResponse
            {
                TotalAmount = totalAmount
            };
            return await Task.FromResult(response);
        }
    }
}