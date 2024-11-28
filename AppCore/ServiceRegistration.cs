using AppCore.Interfaces;
using AppCore.Mappings;
using AppCore.Services;
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

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductCategoryService, ProductCategoryService>();

            services.AddAutoMapper(typeof(MapperProfile));

            return services;
        }
    }
}

