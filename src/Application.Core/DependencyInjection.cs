namespace Application
{
    using System.Reflection;
    using Business.RecommendedProductLogic;
    using Business.SortingProductsLogic;
    using Business.TrolleyAmountCalculator;
    using Common.Behaviours;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;

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
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(RequestValidationBehavior<,>));
        }
    }
}