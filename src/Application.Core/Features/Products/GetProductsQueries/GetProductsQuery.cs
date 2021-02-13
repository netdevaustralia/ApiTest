namespace Application.Features.Products.Queries
{
    using Application.Business;
    using Application.Services;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetProductsQueryHandler : IRequestHandler<GetProductsRequest, GetProductsResponse>
    {
        private readonly IProductService _productService;
        private readonly ISortingProductLogic _sortingProductLogic;
        private readonly IRecommendedProductLogic _recommendedProductLogic;

        public GetProductsQueryHandler(IProductService productService, ISortingProductLogic sortingProductLogic, IRecommendedProductLogic recommendedProductLogic)
        {
            _productService = productService;
            _sortingProductLogic = sortingProductLogic;
            _recommendedProductLogic = recommendedProductLogic;
        }

        public async Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            if (request.SortOption == Common.Enums.SortOption.Recommended)
            {
                var shopperHistories = await _productService.GetShopperHistoryAsync();
                var recommendedProducts = _recommendedProductLogic.SortRecommendedProducts(shopperHistories);
                return new GetProductsResponse
                {
                    Products = recommendedProducts
                };
            }
            else
            {
                var products = await _productService.GetProductsAsync();
                var sortedProductList = _sortingProductLogic.GetSortedProductList(request.SortOption, products);
                return new GetProductsResponse
                {
                    Products = sortedProductList
                };
            }
        }
    }
}