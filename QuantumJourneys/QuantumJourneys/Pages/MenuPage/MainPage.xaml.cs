//Класс для работы с первой страницей - выбора режима игры (меню)
//------------------------------------------------------------------------------------------------------------------------------

using Plugin.Maui.Audio;

namespace QuantumJourneys;

//------------------------------------------------------------------------------------------------------------------------------

public partial class MainPage : ContentPage
{
    //--------------------------------------------------------------------------------------------------------------------------

    public string currentLanguage;
    private readonly IAudioManager audioManager;

    //--------------------------------------------------------------------------------------------------------------------------
    public MainPage()
    {
        InitializeComponent();
        new SettingsText(this);
    }

    public MainPage(IAudioManager audioManager)
	{
		InitializeComponent();
        new SettingsText(this);
        this.audioManager = audioManager;
        test();
    }

    private async void test()
    {
        var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("test.mp3"));
        player.Loop = true;
        player.Play();
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async void OnSoloButtonClicked(object sender, EventArgs args)
    {
        await Navigation.PushModalAsync(new NewOrOldGameSolo());
    }
    private async void OnMultyButtonClicked(object sender, EventArgs args)
    {
        await Navigation.PushModalAsync(new CreateGameMultyPage());
    }
    private async void OnSettingButtonClicked(object sender, EventArgs args)
    {
        await Navigation.PushModalAsync(new SettingsPage(currentLanguage));
    }
    private void OnExitButtonClicked(object sender, EventArgs args)
    {
        App.Current.Quit();
    }
    //--------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------

