using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Repositories.implementations;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppCore
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddCoreAndDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(
                 options => options.UseSqlServer(configuration.GetConnectionString("Principal"))
            );

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
