using EFCorePOC.Application.Contracts;
using EFCorePOC.Persistence.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EFCorePOC.Persistence.cs
{
    public static class PersistenceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connString = configuration.GetConnectionString("Oracle");
            services.AddScoped<ISubscriberRepository, SubscriberRepository>();
            services.AddDbContext<ModelContext>(options =>
            {
                options.UseOracle(connString);
            });
            return services;
        }
    }
}
