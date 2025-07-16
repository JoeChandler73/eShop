using Basket.Api.Extensions;
using Common.Configuration;

var app = CreateWebApplication(args);
app.Run();

static WebApplication CreateWebApplication(string[] args)
{
    var builder = WebApplication.CreateBuilder(args);
    builder.ConfigureDefaults();
    builder.ConfigureServices();
    
    var app = builder.Build();
    app.ConfigureDefaults();
    
    return app;
}