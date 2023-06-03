using Core.EntityFramework;
using Microsoft.EntityFrameworkCore;
using NotIlya.Extensions.ServiceProvider;

namespace Startup.Extensions;

public static class AppExtensions
{
    public static async Task ConfigureDb(this WebApplication app, bool autoMigrate)
    {
        if (autoMigrate)
        {
            await app.Services.UsingScopeAsync<AppDbContext>(async dbContext => await dbContext.Database.MigrateAsync());
        }
    }
}