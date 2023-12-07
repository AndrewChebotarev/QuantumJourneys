//Класс для работы со статистикой
//--------------------------------------------------------------------------------------------------------------------------------------

namespace QuantumJourneys.Pages.Statistics;

//--------------------------------------------------------------------------------------------------------------------------------------
public partial class StatisticsPage : ContentPage
{
    //----------------------------------------------------------------------------------------------------------------------------------
    public StatisticsPage()
	{
#if DEBUG
        MyLogger.logger.LogInformation("Начало инициализации страницы статистики.");
#endif
        InitializeComponent();
#if DEBUG
        MyLogger.logger.LogInformation("Конец инициализации страницы статистики.");
#endif
    }
    //----------------------------------------------------------------------------------------------------------------------------------
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
    //----------------------------------------------------------------------------------------------------------------------------------
}
//--------------------------------------------------------------------------------------------------------------------------------------