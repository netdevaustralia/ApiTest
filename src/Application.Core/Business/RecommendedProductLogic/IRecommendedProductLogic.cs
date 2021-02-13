namespace Application.Business
{
    using Application.Common.Models;
    using System.Collections.Generic;

    public interface IRecommendedProductLogic
    {
        List<Product> SortRecommendedProducts(List<ShopperHistory> shopperHistories);
    }
}