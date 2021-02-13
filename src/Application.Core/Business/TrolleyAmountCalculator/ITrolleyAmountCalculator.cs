namespace Application.Business.TrolleyAmountCalculator
{
    using Application.Common.Models;
    using System.Collections.Generic;

    public interface ITrolleyAmountCalculator
    {
        decimal CalculateLowestPrice(List<Product> products, List<Special> specials, List<ProductQuantity> productQuantities);
    }
}