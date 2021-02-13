namespace Application.Test.Business
{
    using Application.Business;
    using Application.Common.Models;
    using FluentAssertions;
    using System.Collections.Generic;
    using Xunit;

    public class SortingProductLogicTests
    {
        [Fact]
        public void GetSortedProductList_ByLowPrice_ReturnsProductsInAscendingOrderOfPrice()
        {
            // Arrange
            var sortingProductLogic = new SortingProductLogic();
            var productList = new List<Product>
            {
                new Product
                {
                    Name ="A",
                    Price =10
                },
                new Product
                {
                    Name ="B",
                    Price =5
                },
                new Product
                {
                    Name ="C",
                    Price = 13.5m
                }
            };

            // Act
            var sortedProducts = sortingProductLogic.GetSortedProductList(Common.Enums.SortOption.Low, productList);

            // Assert
            sortedProducts.Should().BeInAscendingOrder(x => x.Price);
        }

        [Fact]
        public void GetSortedProductList_ByHighPrice_ReturnsProductsInDescendingOrderOfPrice()
        {
            // Arrange
            var sortingProductLogic = new SortingProductLogic();
            var productList = new List<Product>
            {
                new Product
                {
                    Name ="A",
                    Price =10
                },
                new Product
                {
                    Name ="B",
                    Price =5
                },
                new Product
                {
                    Name ="C",
                    Price = 13.5m
                }
            };

            // Act
            var sortedProducts = sortingProductLogic.GetSortedProductList(Common.Enums.SortOption.High, productList);

            // Assert
            sortedProducts.Should().BeInDescendingOrder(x => x.Price);
        }

        [Fact]
        public void GetSortedProductList_ByAscendingOrder_ReturnsProductsInAscendingOrderOfName()
        {
            // Arrange
            var sortingProductLogic = new SortingProductLogic();
            var productList = new List<Product>
            {
                new Product
                {
                    Name ="A"
                },
                new Product
                {
                    Name ="C"
                },
                new Product
                {
                    Name ="B"
                }
            };

            // Act
            var sortedProducts = sortingProductLogic.GetSortedProductList(Common.Enums.SortOption.Ascending, productList);

            // Assert
            sortedProducts.Should().BeInAscendingOrder(x => x.Name);
        }

        [Fact]
        public void GetSortedProductList_ByDescendingOrder_ReturnsProductsInDescendingOrderOfName()
        {
            // Arrange
            var sortingProductLogic = new SortingProductLogic();
            var productList = new List<Product>
            {
                new Product
                {
                    Name ="A"
                },
                new Product
                {
                    Name ="C"
                },
                new Product
                {
                    Name ="B"
                }
            };

            // Act
            var sortedProducts = sortingProductLogic.GetSortedProductList(Common.Enums.SortOption.Descending, productList);

            // Assert
            sortedProducts.Should().BeInDescendingOrder(x => x.Name);
        }
    }
}