using Core.EntityFramework.Repositories;
using Core.Services;

namespace Startup.Extensions;

public static class DiExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, ProductService>();
    }
}