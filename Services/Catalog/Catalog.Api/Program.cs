using Catalog.Application.Queries;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Entities;
using Catalog.Infrastructure.Repositories;
using Catalog.Infrastructure.Settings;
using Common.Logging;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "Catalog.API", Version = "v1"}); });
builder.Services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(GetAllBrandsQuery).Assembly));
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(ProductBrandEntity));
builder.Services.AddScoped<ICatalogContext, CatalogContext>();
builder.Services.AddScoped<IBrandRepository, ProductRepository>();

builder.Host.UseSerilog(Logging.ConfigureLogger);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog.Api v1"));
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
