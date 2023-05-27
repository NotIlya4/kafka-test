using Api;
using ExceptionCatcherMiddleware.Api;
using NotIlya.Extensions.SerilogExtensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;
ConfigurationManager config = builder.Configuration;

services.AddExceptionCatcherMiddlewareServices();
services.AddConfiguredSerilog(config.GetAddConfigurationOptions("Serilog"));

services.AddControllers().AddApplicationPart(typeof(ProductController).Assembly);
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

WebApplication app = builder.Build();

app.UseSerilogRequestLogging();
app.UseExceptionCatcherMiddleware();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();
