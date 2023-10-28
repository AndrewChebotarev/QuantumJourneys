//Класс для работы с первой страницей - выбора режима игры (меню)
//------------------------------------------------------------------------------------------------------------------------------

using Plugin.Maui.Audio;

namespace QuantumJourneys;

//------------------------------------------------------------------------------------------------------------------------------

public partial class MainPage : ContentPage
{

    private readonly IAudioManager audioManager;
    //--------------------------------------------------------------------------------------------------------------------------
    public MainPage()
    {
        InitializeComponent();
        new SettingMenuText(this);
    }

    public MainPage(IAudioManager audioManager)
	{
		InitializeComponent();
        new SettingMenuText(this);
        this.audioManager = audioManager;
        test();
    }

    private async void test()
    {
        var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("test.mp3"));
        player.Play();
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private void OnSoloButtonClicked(object sender, EventArgs args)
    {
        NewOrOldGameSolo nextPage = new NewOrOldGameSolo();
        CloseAndOpenPage(nextPage);
    }
    private void OnMultyButtonClicked(object sender, EventArgs args)
    {
        CreateGameMultyPage nextPage = new CreateGameMultyPage();
        CloseAndOpenPage(nextPage);
    }
    private void OnSettingButtonClicked(object sender, EventArgs args)
    {
        SettingPage nextPage = new SettingPage();
        CloseAndOpenPage(nextPage);
    }
    private void OnExitButtonClicked(object sender, EventArgs args)
    {
        App.Current.Quit();
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private void CloseAndOpenPage(Page newPage)
    {
        Application.Current.MainPage.Navigation.PopAsync();
        Application.Current.MainPage = newPage;
    }
    //--------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------

