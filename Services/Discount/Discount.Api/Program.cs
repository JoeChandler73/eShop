using Common.Logging;
using Discount.Api.Extensions;
using Discount.Api.Services;
using Discount.Infrastructure.Extensions;
using Serilog;

var app = CreateWebApplication(args);
app.Run();
static WebApplication CreateWebApplication(string[] args)
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog(Logging.ConfigureLogger);
    builder.ConfigureServices();
    
    var app = builder.Build();
    app.MapGrpcService<DiscountService>();
    app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client.");
    app.MigrateDatabase<Program>();
    
    return app;
}