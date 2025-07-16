using Catalog.Api.Extensions;
using Common.Configuration;
using Common.Logging;
using Serilog;

var app = CreateWebApplication(args);
app.Run();

static WebApplication CreateWebApplication(string[] args)
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog(Logging.ConfigureLogger);
    builder.ConfigureDefaults();
    builder.ConfigureServices();
    
    var app = builder.Build();
    app.ConfigureDefaults();
    
    return app;
}
