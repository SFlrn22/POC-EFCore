using EFCorePOC.Application.Contracts;
using EFCorePOC.Application.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace EFCorePOC.Application
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ISubscriberService, SubscriberService>();
            return services;
        }
    }
}
