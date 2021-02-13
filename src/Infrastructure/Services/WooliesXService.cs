namespace Application.Services
{
    using Application.Common.Exceptions;
    using Application.Common.Models;
    using Application.Core.Config;
    using Application.Core.Utils;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Mime;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class WooliesXService : IProductService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<WooliesXService> _logger;
        private readonly ProductServiceConfig _productServiceConfig;

        public WooliesXService(HttpClient httpClient, IOptions<ProductServiceConfig> productServiceConfig, ILogger<WooliesXService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            _productServiceConfig = productServiceConfig.Value;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            using var responseMessage = await _httpClient.GetAsync($"products?token={_productServiceConfig.Token}");
            try
            {
                var stream = await responseMessage.Content.ReadAsStreamAsync();
                responseMessage.EnsureSuccessStatusCode();
                var serializerOptions = JsonSerializerExtensions.GetDefaultJsonSerializerOptions();
                return await JsonSerializer.DeserializeAsync<List<Product>>(stream, serializerOptions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductServiceException.GetProductsAsync");
                throw new ProductServiceException($"ProductServiceException.GetProductsAsync {ex.Message} {responseMessage.StatusCode}");
            }
        }

        public async Task<List<ShopperHistory>> GetShopperHistoryAsync()
        {
            using var responseMessage = await _httpClient.GetAsync($"shopperHistory?token={_productServiceConfig.Token}");
            try
            {
                var stream = await responseMessage.Content.ReadAsStreamAsync();
                responseMessage.EnsureSuccessStatusCode();
                var serializerOptions = JsonSerializerExtensions.GetDefaultJsonSerializerOptions();
                return await JsonSerializer.DeserializeAsync<List<ShopperHistory>>(stream, serializerOptions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductServiceException.GetShopperHistoryAsync");
                throw new ProductServiceException($"ProductServiceException.GetShopperHistoryAsync {ex.Message} {responseMessage.StatusCode}");
            }
        }

        public async Task<decimal> GetTrollyTotalAsync(TrolleyTotalRequest request)
        {
            HttpContent httpContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, MediaTypeNames.Application.Json);
            using var responseMessage = await _httpClient.PostAsync($"trolleyCalculator?token={_productServiceConfig.Token}", httpContent);
            try
            {
                var response = await responseMessage.Content.ReadAsStreamAsync();
                responseMessage.EnsureSuccessStatusCode();
                var serializerOptions = JsonSerializerExtensions.GetDefaultJsonSerializerOptions();
                return await JsonSerializer.DeserializeAsync<decimal>(response, serializerOptions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductServiceException.GetTrollyTotalAsync");
                throw new ProductServiceException($"ProductServiceException, {ex.Message} {responseMessage.StatusCode}");
            }
        }
    }
}