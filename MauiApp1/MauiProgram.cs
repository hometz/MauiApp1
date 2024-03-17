using MauiApp1.Services;
using Microsoft.Extensions.Logging;
using MauiApp1.Entities;


namespace MauiApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder.Services.AddTransient<IDbService, SqLiteService>();
            builder.Services.AddTransient<DataBase>();
            builder.Services.AddTransient<RateService>();
            builder.Services.AddHttpClient<IRateService>(opt =>
                opt.BaseAddress = new Uri("https://www.nbrb.by/api/exrates/rates"));

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

                

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
