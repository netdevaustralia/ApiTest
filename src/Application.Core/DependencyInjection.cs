namespace Application.Core
{
    using Application.Behaviours;
    using Application.Business;
    using Application.Business.TrolleyAmountCalculator;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatRWithPipeline();
            services.AddScoped<ISortingProductLogic, SortingProductLogic>();
            services.AddScoped<IRecommendedProductLogic, RecommendedProductLogic>();
            services.AddScoped<ITrolleyAmountCalculator, TrolleyAmountCalculator>();
            return services;
        }

        private static void AddMediatRWithPipeline(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        }
    }
}