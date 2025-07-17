using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Common.Configuration;

public static class ServiceExtensions
{
    public static IServiceCollection ConfigureDefaults(this IServiceCollection services)
    {
        services.AddDefaultHealthChecks();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddControllers();
        
        return services;
    }
    
    private static IServiceCollection AddDefaultHealthChecks(this IServiceCollection services)
    {
        services.AddHealthChecks();
        
        return services;
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