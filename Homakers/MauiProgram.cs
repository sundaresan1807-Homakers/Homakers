using Homakers.Applications;
using Homakers.Sevices;
using Homakers.SQLite;
using Microsoft.Extensions.Logging;

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
            builder.Services.AddScoped<HttpClient, HttpClient>();

            builder.Services.AddSingleton<SQLiteInitializer>();
            builder.Services.AddSingleton<ProfessionSQLiteServices>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
