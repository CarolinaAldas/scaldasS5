using Microsoft.Extensions.Logging;
using scaldasS5.Repositories;
using scaldasS5.Utils;

namespace scaldasS5
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

            string dbPath = FileAccessHelper.GetFolderPath("personasDB.db3");
            builder.Services.AddSingleton<PersonRepository>(s =>
                ActivatorUtilities.CreateInstance<PersonRepository>(s, dbPath));

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}