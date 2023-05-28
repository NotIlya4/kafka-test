using Api;
using Core.EntityFramework;
using ExceptionCatcherMiddleware.Api;
using NotIlya.Extensions.EntityFrameworkExtensions;
using NotIlya.Extensions.SerilogExtensions;
using Serilog;
using Startup.Extensions;

var builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;
ConfigurationManager config = builder.Configuration;

services.AddExceptionCatcherMiddlewareServices();
services.NAddSerilog(config.GetNAddSerilogOptions("Serilog"));
services.NAddEfSqlServer<AppDbContext>(config.GetNAddEfSqlServerOptions("SqlServer"));
services.AddServices();

services.AddControllers().AddApplicationPart(typeof(ProductController).Assembly);
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

WebApplication app = builder.Build();

await app.ConfigureDb(config.AutoMigrate());

app.UseSerilogRequestLogging();
app.UseExceptionCatcherMiddleware();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();
