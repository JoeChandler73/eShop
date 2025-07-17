using Basket.Api.Extensions;
using Common.Configuration;
using Common.Logging;
using Serilog;

var app = CreateWebApplication(args);
app.Run();

static WebApplication CreateWebApplication(string[] args)
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog(Logging.ConfigureLogger);
    builder.Services.ConfigureDefaults();
    builder.Services.ConfigureServices(builder.Configuration);
    
    var app = builder.Build();
    app.ConfigureDefaults();
    
    return app;
}