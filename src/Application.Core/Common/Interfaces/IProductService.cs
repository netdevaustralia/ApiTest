namespace Application.Services
{
    using Application.Common.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();

        Task<List<ShopperHistory>> GetShopperHistoryAsync();

        Task<decimal> GetTrollyTotalAsync(TrolleyTotalRequest request);
    }
}