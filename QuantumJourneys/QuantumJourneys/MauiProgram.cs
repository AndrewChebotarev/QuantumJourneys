﻿//Класс для запуска приложения
//-----------------------------------------------------------------------------------------------------------------------------

namespace QuantumJourneys;

//------------------------------------------------------------------------------------------------------------------------------

public static class MauiProgram
{
    //--------------------------------------------------------------------------------------------------------------------------
    public static MauiApp CreateMauiApp()
	{
        var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkitMediaElement()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton(AudioManager.Current);
		builder.Services.AddTransient<App>();

#if DEBUG
		builder.Logging.AddTraceLogger(_ => { });
		builder.Services.AddTransient<MainPage>();
#endif

        return builder.Build();
	}
    //--------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------
