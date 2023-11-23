//Класс для работы с первой страницей - выбора режима игры (меню)
//------------------------------------------------------------------------------------------------------------------------------

namespace QuantumJourneys;

//------------------------------------------------------------------------------------------------------------------------------

public partial class MainPage : ContentPage
{
    //--------------------------------------------------------------------------------------------------------------------------

    private bool isBusy = false;

    //--------------------------------------------------------------------------------------------------------------------------
    public MainPage(IAudioManager audioManager, ILogger<MainPage> logger)
	{
#if DEBUG
        logger.LogInformation("Начало инициализации главного меню игры.");
#endif
        InitializeComponent();
#if DEBUG
        InitLogger(logger);
#endif
        InitAudio(audioManager);
        new SettingsInit(this);
#if DEBUG
        MyLogger.logger.LogInformation("Конец инициализации главного меню игры.");
#endif
    }
    //--------------------------------------------------------------------------------------------------------------------------

#if DEBUG
    private void InitLogger(ILogger<MainPage> logger)
    {
        MyLogger.logger = logger;
        MyLogger.logger.LogInformation("Логгер инициализирован!");
    }
#endif
    private async void InitAudio(IAudioManager audioManager)
    {
        WorkingAudioPlayer.audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("Menu.mp3"));
        WorkingAudioPlayer.audioPlayer.Volume = new();
        WorkingAudioPlayer.audioPlayer.Loop = true;
        WorkingAudioPlayer.audioPlayer.Play();

#if DEBUG
        MyLogger.logger.LogInformation("Инициализация аудименеджера, аудио плеера пройдена.");
#endif
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async void OnSoloButtonClicked(object sender, EventArgs args)
    {
        if (!isBusy)
        {
            isBusy = true;
            await Navigation.PushModalAsync(new NewOrLoadGameSoloPage());
            isBusy = false;
#if DEBUG
            MyLogger.logger.LogInformation("Переход на страницу выбора одиночной игры - успешен.");
#endif
            return;
        }
#if DEBUG
        MyLogger.logger.LogInformation("Кнопка открытия страницы выбора одиночной игры - занята!");
#endif
    }
    private async void OnMultyButtonClicked(object sender, EventArgs args)
    {
        if (!isBusy)
        {
            isBusy = true;
            await Navigation.PushModalAsync(new CreateGameMultyPage());
            isBusy = false;
#if DEBUG
            MyLogger.logger.LogInformation("Переход на страницу выбора многопользовательской игры - успешен.");
#endif
            return;
        }
#if DEBUG
        MyLogger.logger.LogInformation("Кнопка открытия страницы выбора многопользовательской игры - занята!");
#endif

    }
    private async void StatisticsBtn_Clicked(object sender, EventArgs e)
    {
        if (!isBusy)
        {
            isBusy = true;
            await Navigation.PushModalAsync(new StatisticsPage()); ;
            isBusy = false;
#if DEBUG
            MyLogger.logger.LogInformation("Переход на страницу статистики - успешен.");
#endif
        }
#if DEBUG
        MyLogger.logger.LogInformation("Кнопка открытия страницы статистики - занята!");
#endif
    }
    private async void OnSettingButtonClicked(object sender, EventArgs args)
    {
        if (!isBusy)
        {
            isBusy = true;
            await Navigation.PushModalAsync(new SettingsPage(this));
            isBusy = false;
#if DEBUG
            MyLogger.logger.LogInformation("Переход на страницу настройки - успешен.");
#endif
            return;
        }
#if DEBUG
        MyLogger.logger.LogInformation("Кнопка открытия страницы настройки - занята!");
#endif
    }
    private void OnExitButtonClicked(object sender, EventArgs args)
    {
#if DEBUG
        MyLogger.logger.LogInformation("Кнопка выхода из игры - нажата!");
#endif
        App.Current.Quit();
    }
    //--------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------

