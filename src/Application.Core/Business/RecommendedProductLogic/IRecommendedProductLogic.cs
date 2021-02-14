namespace Application.Business.RecommendedProductLogic
{
    using System.Collections.Generic;
    using Common.Models;

    public interface IRecommendedProductLogic
    {
        List<Product> SortRecommendedProducts(List<ShopperHistory> shopperHistories);
    }
}