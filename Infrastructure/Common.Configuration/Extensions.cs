using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Common.Configuration;

public static class Extensions
{
    public static WebApplicationBuilder ConfigureDefaults(this WebApplicationBuilder builder)
    {
        builder.AddDefaultHealthChecks();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();
        
        return builder;
    }
    
    private static IHostApplicationBuilder AddDefaultHealthChecks(this IHostApplicationBuilder builder)
    {
        builder.Services.AddHealthChecks();
        
        return builder;
    }

    public static void ConfigureDefaults(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseStaticFiles();
        app.MapControllers();
        app.MapHealthChecks("/health");
    }
}