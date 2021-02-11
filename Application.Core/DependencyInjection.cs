using Application.Core.Services.UserService;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatRWithPipeline();
            services.AddScoped<IUserService, UserService>();
            return services;
        }

        private static void AddMediatRWithPipeline(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
           // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
           // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        }

    }
}
