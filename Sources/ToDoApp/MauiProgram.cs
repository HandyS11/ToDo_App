using CommunityToolkit.Maui;
using Database;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Model;
using Stub;
using ToDoApp.ViewModels;
using VM;
using static Android.Provider.CalendarContract;

namespace ToDoApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>()
                   .UseMauiCommunityToolkit()
                   .ConfigureFonts(fonts =>
                   {
                       fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                       fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                   });

            builder.Services.AddSingleton<IDataManager, ToDosDatabase>()    // It can be replaced with: StubData
                            .AddSingleton<ToDosManagerVM>()
                            .AddSingleton<AddOrEditToDoVM>()
                            .AddSingleton<AppVM>()
                            .AddSingleton<App>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}