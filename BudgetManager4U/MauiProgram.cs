using BudgetManager4U.Service;
using BudgetManager4U.Views;
using Microsoft.Extensions.Logging;
using BudgetManager4U.ViewModels;

namespace BudgetManager4U
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // builder.Services.AddSingleton<DatabaseContext>();
            builder.Services.AddTransient<UserAccountPage>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<UserViewModel>();
            builder.Services.AddTransient<SignUpPage>();
            builder.Services.AddSingleton<DatabaseContext>();
            
            builder.Services.AddSingleton<UserService>();




#if DEBUG
            builder.Logging.AddDebug();
           
           
#endif

            return builder.Build();
        }
    }
}
