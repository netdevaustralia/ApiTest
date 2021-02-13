namespace Application.Business
{
    using Application.Common.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class RecommendedProductLogic : IRecommendedProductLogic
    {
        public List<Product> SortRecommendedProducts(List<ShopperHistory> shopperHistories)
        {
            var productList = new List<Product>();
            foreach (var shopperHistory in shopperHistories)
            {
                foreach (var product in shopperHistory.Products)
                {
                    if (productList.Exists(x => x.Name == product.Name))
                    {
                        var existingProduct = productList.Single(x => x.Name == product.Name);
                        existingProduct.Quantity += product.Quantity;
                    }
                    else
                    {
                        productList.Add(product);
                    }
                }
            }
            return productList.OrderByDescending(x => x.Quantity).ToList();
        }
    }
}