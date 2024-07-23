using Microsoft.Extensions.Logging;
using BudgetManager4U.Models;
using BudgetManager4U.Views;
using BudgetManager4U.Services;
namespace BudgetManager4U;

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

#if DEBUG
        builder.Logging.AddDebug();
#endif      
        builder.Services.AddSingleton<LocalDbService>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<ExpensesPage>();
        builder.Services.AddTransient<IncomesPage>();


        return builder.Build();
    }
}
