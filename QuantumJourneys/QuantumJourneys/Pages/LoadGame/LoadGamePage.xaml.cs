//Класс для загрузки игры
//------------------------------------------------------------------------------------------------------------------------------

namespace QuantumJourneys.Pages.LoadGame;

//------------------------------------------------------------------------------------------------------------------------------
public partial class LoadGamePage : ContentPage
{
    //--------------------------------------------------------------------------------------------------------------------------
    public LoadGamePage()
	{
#if DEBUG
        MyLogger.logger.LogInformation("Начало инициализации страницы загрузки игры.");
#endif
        InitializeComponent();
#if DEBUG
        MyLogger.logger.LogInformation("Конец инициализации страницы загрузки игры.");
#endif
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async void BackBtn_Clicked(object sender, EventArgs e)
    {
        if (!CheckProcessBusy.isProcessBusy)
        {
            CheckProcessBusy.isProcessBusy = true;
            await Navigation.PopModalAsync();
            CheckProcessBusy.isProcessBusy = false;
#if DEBUG
            MyLogger.logger.LogInformation("Переход на страницу меню - успешен.");
#endif
            return;
        }
#if DEBUG
        MyLogger.logger.LogInformation("Кнопка открытия страницы меню - занята!");
#endif
    }
    //--------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------