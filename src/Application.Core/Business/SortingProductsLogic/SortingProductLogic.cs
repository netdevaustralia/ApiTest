namespace Application.Business.SortingProductsLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common.Enums;
    using Common.Models;

    public class SortingProductLogic : ISortingProductLogic
    {
        public List<Product> GetSortedProductList(SortOption sortOption, List<Product> products)
        {
            switch (sortOption)
            {
                case SortOption.Low:
                case SortOption.High:
                    return SortByKey(products, p => p.Price, sortOption);

                case SortOption.Ascending:
                case SortOption.Descending:
                    return SortByKey(products, p => p.Name, sortOption);
                default:
                    throw new ArgumentOutOfRangeException(nameof(sortOption), sortOption, null);
            }
        }

        private static List<Product> SortByKey<TKey>(List<Product> list, Func<Product, TKey> sortKey,
            SortOption sortOption)
        {
            list = sortOption == SortOption.Ascending || sortOption == SortOption.Low
                ? list.OrderBy(sortKey).ToList()
                : list.OrderByDescending(sortKey).ToList();

            return list;
        }
    }
}