namespace QuantumJourneys.Pages.MiniGame.OpenDoor;

public partial class MiniGame_OpenDoor : ContentPage
{
    //--------------------------------------------------------------------------------------------------------------------------

    private bool isBusy = false;

    //--------------------------------------------------------------------------------------------------------------------------
    public MiniGame_OpenDoor()
    {
#if DEBUG
        MyLogger.logger.LogInformation("Начало инициализации мини игры.");
#endif
        InitializeComponent();
#if DEBUG
        MyLogger.logger.LogInformation("Конец инициализации мини игры.");
#endif
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async void BackBtn_Clicked(object sender, EventArgs e)
    {
        if (!isBusy)
        {
            isBusy = true;
            await Navigation.PopModalAsync();
            isBusy = false;
#if DEBUG
            MyLogger.logger.LogInformation("Переход на страницу мини игра - успешен.");
#endif
            return;
        }
#if DEBUG
        MyLogger.logger.LogInformation("Кнопка открытия страницы мини игра - занята!");
#endif
    }
}