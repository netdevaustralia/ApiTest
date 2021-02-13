namespace Application.Tests.Features
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Business.RecommendedProductLogic;
    using Application.Business.SortingProductsLogic;
    using Application.Features.Products.GetProductsQueries;
    using Common.Enums;
    using Common.Interfaces;
    using Moq;
    using Xunit;

    public class GetProductsQueriesTests
    {
        [Fact]
        public async Task
            Handle_SortOptionNotRecommended_ShouldNotInvokeProductServiceGetShopperHistoryOnce()
        {
            // Arrange
            var productService = new Mock<IProductService>();
            var sortingProductLogic = new Mock<ISortingProductLogic>();
            var recommendedProductLogic = new Mock<IRecommendedProductLogic>();
            var queryHandler = new GetProductsQueryHandler(productService.Object,
                sortingProductLogic.Object, recommendedProductLogic.Object);
            var productRequest = new GetProductsRequest {SortOption = SortOption.Low};

            // Act
            await queryHandler.Handle(productRequest, CancellationToken.None);

            // Assert
            productService.Verify(x => x.GetShopperHistoryAsync(), Times.Never);
        }


        [Fact]
        public async Task
            Handle_SortOptionRecommended_ShouldInvokeProductServiceGetShopperHistoryOnce()
        {
            // Arrange
            var productService = new Mock<IProductService>();
            var sortingProductLogic = new Mock<ISortingProductLogic>();
            var recommendedProductLogic = new Mock<IRecommendedProductLogic>();
            var queryHandler = new GetProductsQueryHandler(productService.Object,
                sortingProductLogic.Object, recommendedProductLogic.Object);
            var productRequest = new GetProductsRequest {SortOption = SortOption.Recommended};

            // Act
            await queryHandler.Handle(productRequest, CancellationToken.None);

            // Assert
            productService.Verify(x => x.GetShopperHistoryAsync(), Times.Once);
        }
    }
}