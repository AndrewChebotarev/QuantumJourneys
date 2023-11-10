//Класс для работы с первой страницей - выбора режима игры (меню)
//------------------------------------------------------------------------------------------------------------------------------

namespace QuantumJourneys;

//------------------------------------------------------------------------------------------------------------------------------

public partial class MainPage : ContentPage
{
    //--------------------------------------------------------------------------------------------------------------------------

    public string currentLanguage;
    public IAudioManager audioManager;
    private IAudioPlayer audioPlayer;

    //--------------------------------------------------------------------------------------------------------------------------
    public MainPage(IAudioManager audioManager)
	{
		InitializeComponent();
        InitAudio(audioManager);
        new SettingsInit(this, audioPlayer);
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async void InitAudio(IAudioManager audioManager)
    {
        this.audioManager = audioManager;
        IAudioPlayer player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("Menu.mp3"));
        audioPlayer = player;
        player.Loop = true;
        player.Play();
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async void OnSoloButtonClicked(object sender, EventArgs args)
    {
        await Navigation.PushModalAsync(new NewOrLoadGameSoloPage(currentLanguage));
    }
    private async void OnMultyButtonClicked(object sender, EventArgs args)
    {
        await Navigation.PushModalAsync(new CreateGameMultyPage());
    }
    private async void OnSettingButtonClicked(object sender, EventArgs args)
    {
        await Navigation.PushModalAsync(new SettingsPage(currentLanguage, audioPlayer));
    }
    private void OnExitButtonClicked(object sender, EventArgs args)
    {
        App.Current.Quit();
    }
    //--------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------

