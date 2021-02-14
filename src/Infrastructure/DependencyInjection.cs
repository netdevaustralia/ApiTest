namespace Infrastructure
{
    using System;
    using Application.Common.Interfaces;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Polly;
    using Services;

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddHttpClient<IProductService, WooliesXService>(client =>
                {
                    client.BaseAddress =
                        new Uri(configuration["WooliesXServiceConfig:ShopperConfig:BaseUrl"]);
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                }).SetHandlerLifetime(TimeSpan.FromMinutes(5))
                .AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(10)
                }));
            return services;
        }
    }
}