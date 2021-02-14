namespace Application.Features.Products.GetProductsQueries
{
    using System.Threading;
    using System.Threading.Tasks;
    using Business.RecommendedProductLogic;
    using Business.SortingProductsLogic;
    using Common.Enums;
    using Common.Interfaces;
    using MediatR;

    public class GetProductsQueryHandler : IRequestHandler<GetProductsRequest, GetProductsResponse>
    {
        private readonly IProductService _productService;
        private readonly IRecommendedProductLogic _recommendedProductLogic;
        private readonly ISortingProductLogic _sortingProductLogic;


        public GetProductsQueryHandler(IProductService productService,
            ISortingProductLogic sortingProductLogic,
            IRecommendedProductLogic recommendedProductLogic)
        {
            _productService = productService;
            _sortingProductLogic = sortingProductLogic;
            _recommendedProductLogic = recommendedProductLogic;
        }


        public async Task<GetProductsResponse> Handle(GetProductsRequest request,
            CancellationToken cancellationToken)
        {
            if (request.SortOption == SortOption.Recommended)
            {
                var shopperHistories = await _productService.GetShopperHistoryAsync();
                var recommendedProducts =
                    _recommendedProductLogic.SortRecommendedProducts(shopperHistories);
                return new GetProductsResponse {Products = recommendedProducts};
            }

            var products = await _productService.GetProductsAsync();
            var sortedProductList =
                _sortingProductLogic.GetSortedProductList(request.SortOption, products);
            return new GetProductsResponse {Products = sortedProductList};
        }
    }
}