namespace Application.Business
{
    using Application.Common.Enums;
    using Application.Common.Models;
    using System.Collections.Generic;

    public interface ISortingProductLogic
    {
        List<Product> GetSortedProductList(SortOption sortOption, List<Product> products);
    }
}