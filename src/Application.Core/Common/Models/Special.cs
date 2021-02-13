namespace Application.Common.Models
{
    using System.Collections.Generic;

    public class Special
    {
        public List<ProductQuantity> Quantities { get; set; }
        public decimal Total { get; set; }
    }
}