namespace Application.Business.TrolleyAmountCalculator
{
    using System;
    using System.Collections.Generic;
    using Common.Models;

    public class TrolleyAmountCalculator : ITrolleyAmountCalculator
    {
        public decimal CalculateLowestPrice(List<Product> products, List<Special> specials,
            List<ProductQuantity> productQuantities)
        {
            throw new NotImplementedException();
        }
    }
}