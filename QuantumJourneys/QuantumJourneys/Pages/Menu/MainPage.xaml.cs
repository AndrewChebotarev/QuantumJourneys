//Класс для работы с первой страницей - выбора режима игры (меню)
//------------------------------------------------------------------------------------------------------------------------------

namespace QuantumJourneys;

//------------------------------------------------------------------------------------------------------------------------------

public partial class MainPage : ContentPage
{
    //--------------------------------------------------------------------------------------------------------------------------
    public MainPage(IAudioManager audioManager)
	{
		InitializeComponent();
        InitAudio(audioManager);
        new SettingsInit(this);
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async void InitAudio(IAudioManager audioManager)
    {
        WorkingAudioPlayer.audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("Menu.mp3"));
        WorkingAudioPlayer.audioPlayer.Loop = true;
        WorkingAudioPlayer.audioPlayer.Play();
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async void OnSoloButtonClicked(object sender, EventArgs args)
    {
        await Navigation.PushModalAsync(new NewOrLoadGameSoloPage());
    }
    private async void OnMultyButtonClicked(object sender, EventArgs args)
    {
        await Navigation.PushModalAsync(new CreateGameMultyPage());
    }
    private async void StatisticsBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new StatisticsPage());
    }
    private async void OnSettingButtonClicked(object sender, EventArgs args)
    {
        await Navigation.PushModalAsync(new SettingsPage(this));
    }
    private void OnExitButtonClicked(object sender, EventArgs args)
    {
        App.Current.Quit();
    }
    //--------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------

