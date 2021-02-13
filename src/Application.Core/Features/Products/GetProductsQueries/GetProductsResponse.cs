namespace Application.Features.Products.GetProductsQueries
{
    using System.Collections.Generic;
    using Common.Models;

    public class GetProductsResponse
    {
        public List<Product> Products { get; set; }
    }
}