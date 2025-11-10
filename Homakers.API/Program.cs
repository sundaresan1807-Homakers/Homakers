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


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HomakerContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HomakerDB")));
// Auto mapper Configuration
builder.Services.AddAutoMapper(typeof(HomakersProfile));

// Services
builder.Services.AddScoped<ICustomerService, CustomersService>();
builder.Services.AddScoped<IProfessionService, ProfessionService>();
builder.Services.AddScoped<IProfessionalsService, ProfessionalsService>();

// Repository
builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();
builder.Services.AddScoped<IProfessionRepository, ProfessionRepository>();
builder.Services.AddScoped<IProfessionalsRepository, ProfessionalsRepository>();


var connectionStringForDbUp = builder.Configuration.GetConnectionString("HomakerDB");


// Seed demo data if in development
#if DEBUG
DatabaseInitializer.EnsureDatabaseAndSchema(connectionStringForDbUp!);
DatabaseInitializer.SeedDemoDataAsync(connectionStringForDbUp!);
#endif

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
