using Core.EntityFramework.Repositories;

namespace Startup.Extensions;

public static class DiExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
    }
}