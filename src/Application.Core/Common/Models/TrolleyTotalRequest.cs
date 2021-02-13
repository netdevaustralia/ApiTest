namespace Application.Common.Models
{
    using System.Collections.Generic;

    public class TrolleyTotalRequest
    {
        public List<Product> Products { get; set; }
        public List<Special> Specials { get; set; }
        public List<ProductQuantity> Quantities { get; set; }
    }
}