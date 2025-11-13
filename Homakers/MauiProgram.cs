using Homakers.Applications;
using Homakers.Sevices;
using Homakers.SQLite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;

namespace Homakers
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            // Auto mapper Configuration
            builder.Services.AddAutoMapper(typeof(HomakersProfile));
            builder.Services.AddScoped<Components.Pages.CustomerComponent.Login, Components.Pages.CustomerComponent.Login>();
            builder.Services.AddScoped<UICustomerService, UICustomerService>();
            builder.Services.AddScoped<UIProfessionalService, UIProfessionalService>();
            builder.Services.AddScoped<UIProfessionsServices, UIProfessionsServices>();
            builder.Services.AddScoped<UIUtilityServices, UIUtilityServices>();
            builder.Services.AddScoped<UIBookServicesService, UIBookServicesService>();
            builder.Services.AddScoped<HttpClient, HttpClient>();

            //builder.Services.AddSingleton<CustomerSQLiteInitializer>();
            builder.Services.AddSingleton<ProfessionSQLiteServices>();
            builder.Services.AddSingleton<GlobalConstants>();

            GlobalConstants.BaseAPIAddress = Environment.GetEnvironmentVariable("APIBaseAddress");
            SQLitePCL.Batteries_V2.Init();
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "HomakerDb.db3");
            builder.Services.AddSingleton(s => new CustomerSQLiteInitializer(dbPath));


#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
