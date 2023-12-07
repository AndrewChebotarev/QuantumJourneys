//Класс для работы с первой страницей - выбора режима игры (меню)
//------------------------------------------------------------------------------------------------------------------------------

namespace QuantumJourneys;

//------------------------------------------------------------------------------------------------------------------------------

public partial class MainPage : ContentPage
{
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
        await WorkWithSound.InitNewAudioPlayer(audioManager, "Menu.mp3");
#if DEBUG
        MyLogger.logger.LogInformation("Инициализация аудименеджера, аудио плеера пройдена.");
#endif
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async void OnSoloButtonClicked(object sender, EventArgs args)
    {
        if (!CheckProcessBusy.isProcessBusy)
        {
            CheckProcessBusy.isProcessBusy = true;
            await Navigation.PushModalAsync(new NewOrLoadGameSoloPage());
            CheckProcessBusy.isProcessBusy = false;
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
        if (!CheckProcessBusy.isProcessBusy)
        {
            CheckProcessBusy.isProcessBusy = true;
            await Navigation.PushModalAsync(new CreateGameMultyPage());
            CheckProcessBusy.isProcessBusy = false;
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
        if (!CheckProcessBusy.isProcessBusy)
        {
            CheckProcessBusy.isProcessBusy = true;
            await Navigation.PushModalAsync(new StatisticsPage()); ;
            CheckProcessBusy.isProcessBusy = false;
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
        if (!CheckProcessBusy.isProcessBusy)
        {
            CheckProcessBusy.isProcessBusy = true;
            await Navigation.PushModalAsync(new SettingsPage(this));
            CheckProcessBusy.isProcessBusy = false;
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

