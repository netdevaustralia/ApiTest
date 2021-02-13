namespace Application.Business.RecommendedProductLogic
{
    using System.Collections.Generic;
    using System.Linq;
    using Common.Models;

    public class RecommendedProductLogic : IRecommendedProductLogic
    {
        public List<Product> SortRecommendedProducts(List<ShopperHistory> shopperHistories)
        {
            var productList = new List<Product>();
            foreach (var product in shopperHistories.SelectMany(shopperHistory =>
                shopperHistory.Products))
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

            return productList.OrderByDescending(x => x.Quantity).ToList();
        }
    }
}