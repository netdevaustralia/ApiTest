namespace Application.Business.TrolleyAmountCalculator
{
    using System.Collections.Generic;
    using Common.Models;

    public interface ITrolleyAmountCalculator
    {
        decimal CalculateLowestPrice(List<Product> products, List<Special> specials,
            List<ProductQuantity> productQuantities);
    }
}