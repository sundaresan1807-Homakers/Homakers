using Homakers.API.Data;
using Homakers.API.Data.DBInterface;
using Homakers.Applications;
using Homakers.Applications.RepoInterfaces;
using Homakers.Applications.Repositories.RepoInterfaces;
using Homakers.Applications.ServiceInterfaces;
using Homakers.Applications.Services;
using Homakers.Domain;
using Homakers.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Homakers_API", Version = "v1" });
});
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HomakerContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("HomakerDB"));
        options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    });

// Auto mapper Configuration
builder.Services.AddAutoMapper(typeof(HomakersProfile));

// Services
builder.Services.AddScoped<ICustomerService, CustomersService>();
builder.Services.AddScoped<IProfessionService, ProfessionService>();
builder.Services.AddScoped<IProfessionalsService, ProfessionalsService>();
builder.Services.AddScoped<IUtilitiesService, UtilitiesService>();
builder.Services.AddScoped<IBookServicesService, BookServicesService>();

// Repository
builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();
builder.Services.AddScoped<IProfessionRepository, ProfessionRepository>();
builder.Services.AddScoped<IProfessionalsRepository, ProfessionalsRepository>();
builder.Services.AddScoped<IUtilityRepository, UtilitiesRepository>();
builder.Services.AddScoped<IBookServiceRepository, BookServiceRepository>();


var connectionStringForDbUp = builder.Configuration.GetConnectionString("HomakerDB");


// Seed demo data if in development
#if DEBUG
DatabaseInitializer.EnsureDatabaseAndSchema(connectionStringForDbUp!);
DatabaseInitializer.SeedDemoDataAsync(connectionStringForDbUp!);
#endif

var app = builder.Build();

app.UseSwagger(c =>
{
    c.PreSerializeFilters.Add((swagger, httpReq) =>
    {
        // Ensure HTTPS URLs in Swagger for production
        if (httpReq.Headers.ContainsKey("X-Forwarded-Proto"))
        {
            swagger.Servers = new List<Microsoft.OpenApi.Models.OpenApiServer>
                {
                    new() { Url = $"https://{httpReq.Host}" }
                };
        }
    });
});

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Payment Poster API v1");
    c.RoutePrefix = "swagger";

    // Add JWT authorization to SwaggerUI
    c.OAuthClientId("swagger-ui");
    c.OAuthAppName("Payment Poster API - Swagger");
    c.OAuthUseBasicAuthenticationWithAccessCodeGrant();

    // Enable authorization persistence
    c.EnablePersistAuthorization();

    // Custom JavaScript to handle JWT token in Swagger UI
    c.InjectJavascript("/swagger-ui/custom.js");

    // Add custom CSS for better styling
    c.InjectStylesheet("/swagger-ui/custom.css");
});

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
