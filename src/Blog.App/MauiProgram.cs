using Blog.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Blog.App;

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

        var a = Assembly.GetExecutingAssembly();
        using var stream = a.GetManifestResourceStream("appsettings.json");
        BuildConfiguration(builder, stream);

        return builder.Build();
    }

    private static void BuildConfiguration(MauiAppBuilder builder, Stream stream)
    {
        var config = new ConfigurationBuilder()
               .AddJsonStream(stream)
               .Build();

        builder.Configuration.AddConfiguration(config);

        var blogSettings = builder.Configuration.GetSection(BlogSettings.AppSettingsSection).Get<BlogSettings>();
        builder.Services.AddSingleton(blogSettings);
    }
}
