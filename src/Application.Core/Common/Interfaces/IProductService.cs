namespace Application.Common.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();

        Task<List<ShopperHistory>> GetShopperHistoryAsync();

        Task<decimal> GetTrollyTotalAsync(TrolleyTotalRequest request);
    }
}