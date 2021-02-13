namespace Application.Business.Tests
{
    using Application.Business;
    using Application.Common.Models;
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class RecommendedProductLogicTests
    {
        [Fact]
        public void SortRecommendedProducts_ValidProductList_ReturnsExpectedResult()
        {
            // Arrange
            var recommendedProductLogic = new RecommendedProductLogic();
            var shopperHistories = new List<ShopperHistory> {
                      new ShopperHistory{
                      CustomerId=1,
                      Products=new List<Product> {
                         new Product {
                             Name="ProductA",
                             Quantity =1
                         }
                        }
                      },
                      new ShopperHistory{
                      CustomerId=2,
                      Products=new List<Product> {
                         new Product {
                             Name="ProductB",
                             Quantity =10
                         }
                        }
                      },
                      new ShopperHistory{
                      CustomerId=1,
                      Products=new List<Product> {
                         new Product {
                             Name="ProductB",
                             Quantity =2
                         }
                        }
                      },
                      new ShopperHistory{
                      CustomerId=3,
                      Products=new List<Product> {
                         new Product {
                             Name="ProductA",
                             Quantity =50
                         }
                        }
                      }
            };

            var expectedResult = new Product{ Name = "ProductA", Quantity = 51, Price = 0 };

            // Act
            var result = recommendedProductLogic.SortRecommendedProducts(shopperHistories);

            // Assert
            result.First().Should().BeEquivalentTo(expectedResult);
        }
    }
}