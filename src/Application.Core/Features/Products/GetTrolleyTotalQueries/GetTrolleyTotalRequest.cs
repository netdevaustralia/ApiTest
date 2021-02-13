namespace Application.Features.Products.GetTrolleyTotalQueries
{
    using Application.Common.Models;
    using MediatR;
    using System.Collections.Generic;

    public class GetTrolleyTotalRequest : IRequest<GetTrolleyTotalResponse>
    {
        public List<Product> Products { get; set; }
        public List<Special> Specials { get; set; }
        public List<ProductQuantity> Quantities { get; set; }
    }
}