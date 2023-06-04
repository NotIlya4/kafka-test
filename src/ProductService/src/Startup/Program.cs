using Api;
using Core.EntityFramework;
using ExceptionCatcherMiddleware.Api;
using NotIlya.Extensions.Configuration;
using NotIlya.Extensions.Serilog;
using NotIlya.Extensions.SqlServer;
using Serilog;
using Startup.Extensions;

var builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;
ConfigurationManager config = builder.Configuration;

services.AddExceptionCatcherMiddlewareServices();
services.AddSerilog(config.GetAddSerilogOptions("Serilog"));
services.AddEfSqlServer<AppDbContext>(config.GetAddEfSqlServerOptions("SqlServer"));
services.AddConfiguredKafka(config.GetKafkaBroker());
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
