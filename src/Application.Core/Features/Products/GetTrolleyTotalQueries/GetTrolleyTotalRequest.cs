namespace Application.Features.Products.GetTrolleyTotalQueries
{
    using System.Collections.Generic;
    using Common.Models;
    using MediatR;

    public class GetTrolleyTotalRequest : IRequest<GetTrolleyTotalResponse>
    {
        public List<Product> Products { get; set; }
        public List<Special> Specials { get; set; }
        public List<ProductQuantity> Quantities { get; set; }
    }
}