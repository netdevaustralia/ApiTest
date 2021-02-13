namespace Application.Features.Products.Queries
{
    using Application.Common.Models;
    using System.Collections.Generic;

    public class GetProductsResponse
    {
        public List<Product> Products { get; set; }
    }
}