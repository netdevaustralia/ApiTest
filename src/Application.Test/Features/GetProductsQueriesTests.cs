namespace Application.Test.Features
{
    using Application.Business;
    using Application.Features.Products.Queries;
    using Application.Services;
    using Moq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class GetProductsQueriesTests
    {
        [Fact]
        public async Task Handle_SortOptionRecommended_ShouldInvokeProductServiceGetShopperHistoryOnce()
        {
            // Arrange
            var productService = new Mock<IProductService>();
            var sortingProductLogic = new Mock<ISortingProductLogic>();
            var recommendedProductLogic = new Mock<IRecommendedProductLogic>();
            var queryHandler = new GetProductsQueryHandler(productService.Object, sortingProductLogic.Object, recommendedProductLogic.Object);
            var productRequest = new GetProductsRequest
            {
                SortOption = Common.Enums.SortOption.Recommended,
            };

            // Act
            await queryHandler.Handle(productRequest, cancellationToken: CancellationToken.None);

            // Assert
            productService.Verify(x => x.GetShopperHistoryAsync(), Times.Once);
        }

        [Fact]
        public async Task Handle_SortOptionNotRecommended_ShouldNotInvokeProductServiceGetShopperHistoryOnce()
        {
            // Arrange
            var productService = new Mock<IProductService>();
            var sortingProductLogic = new Mock<ISortingProductLogic>();
            var recommendedProductLogic = new Mock<IRecommendedProductLogic>();
            var queryHandler = new GetProductsQueryHandler(productService.Object, sortingProductLogic.Object, recommendedProductLogic.Object);
            var productRequest = new GetProductsRequest
            {
                SortOption = Common.Enums.SortOption.Low
            };

            // Act
            await queryHandler.Handle(productRequest, cancellationToken: CancellationToken.None);

            // Assert
            productService.Verify(x => x.GetShopperHistoryAsync(), Times.Never);
        }
    }
}
