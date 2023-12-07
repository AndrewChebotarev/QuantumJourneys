//Класс для мультиплеерной игры
//------------------------------------------------------------------------------------------------------------------------------

namespace QuantumJourneys.Pages.CreateGameMulty;

//------------------------------------------------------------------------------------------------------------------------------

public partial class CreateGameMultyPage : ContentPage
{
    //--------------------------------------------------------------------------------------------------------------------------
    public CreateGameMultyPage()
	{
#if DEBUG
        MyLogger.logger.LogInformation("Начало инициализации выбора многопользовательской игры.");
#endif
        InitializeComponent();
#if DEBUG
        MyLogger.logger.LogInformation("Конец инициализации выбора многопользовательской игры.");
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