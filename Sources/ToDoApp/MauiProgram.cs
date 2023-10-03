using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Model;
using Stub;
using ToDoApp.ViewModels;
using VM;

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

            builder.Services.AddSingleton<IDataManager, StubData>()
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