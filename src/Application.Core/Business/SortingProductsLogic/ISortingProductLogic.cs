namespace Application.Business.SortingProductsLogic
{
    using System.Collections.Generic;
    using Common.Enums;
    using Common.Models;

    public interface ISortingProductLogic
    {
        List<Product> GetSortedProductList(SortOption sortOption, List<Product> products);
    }
}