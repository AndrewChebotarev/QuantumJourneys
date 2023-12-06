namespace QuantumJourneys.Pages.MiniGame.OpenDoor;

public partial class MiniGame_OpenDoor : ContentPage
{
    //--------------------------------------------------------------------------------------------------------------------------

    private bool isBusy = false;

    //--------------------------------------------------------------------------------------------------------------------------
    public MiniGame_OpenDoor()
    {
#if DEBUG
        MyLogger.logger.LogInformation("������ ������������� ���� ����.");
#endif
        InitializeComponent();
#if DEBUG
        MyLogger.logger.LogInformation("����� ������������� ���� ����.");
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
            MyLogger.logger.LogInformation("������� �� �������� ���� ���� - �������.");
#endif
            return;
        }
#if DEBUG
        MyLogger.logger.LogInformation("������ �������� �������� ���� ���� - ������!");
#endif
    }
}