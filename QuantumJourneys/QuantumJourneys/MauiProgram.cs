//Класс для запуска приложения
//-----------------------------------------------------------------------------------------------------------------------------

using Plugin.Maui.Audio;

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
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton(AudioManager.Current);
		builder.Services.AddTransient<MainPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

#if IOS
        AVAudioSession.SharedInstance().SetActive(true);
        AVAudioSession.SharedInstance().SetCategory(AVAudioSessionCategory.Playback);
#endif

        return builder.Build();
	}
    //--------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------
