//����� ��� ������ �� ��������� ������ ����� ���� ��� ��������� ����
//----------------------------------------------------------------------------------------------------------------------------------

namespace QuantumJourneys.Pages;

//----------------------------------------------------------------------------------------------------------------------------------
public partial class NewOrLoadGameSoloPage : ContentPage
{
    //------------------------------------------------------------------------------------------------------------------------------

    private bool isBusy = false;
    private LoadGameSoloPage loadGameSoloPage;

    //------------------------------------------------------------------------------------------------------------------------------
    public NewOrLoadGameSoloPage()
	{
#if DEBUG
        MyLogger.logger.LogInformation("������ ������������� �������� ������ �������� ��� ����� ���� ��� ���������� ������.");
#endif
        InitializeComponent();
        InitLanguage();
        InitLoadGameBtn();
#if DEBUG
        MyLogger.logger.LogInformation("����� ������������� �������� ������ �������� ��� ����� ���� ��� ���������� ������.");
#endif
    }
    //------------------------------------------------------------------------------------------------------------------------------
    private void InitLanguage()
    {
#if DEBUG
        MyLogger.logger.LogInformation("������ ������������� ����� ��� �������� ������ �������� ��� ����� ���� ��� ���������� ������.");
#endif
        switch (SelectLanguage.language)
        {
            case "Ru":
                new NewOrLoadGameSolo_Ru(this);
                break;

            case "En":
                new NewOrLoadGameSolo_En(this);
                break;

            default:
                new NewOrLoadGameSolo_En(this);
                break;
        }
    }
    private void InitLoadGameBtn()
    {
#if DEBUG
        MyLogger.logger.LogInformation("������ �������� �� ����������.");
#endif
        LoadGameSoloPage loadGameSoloPage = new();
        this.loadGameSoloPage = loadGameSoloPage;
        LoadGameBtn.IsVisible = loadGameSoloPage.CheckOldGame();

#if DEBUG
        if (LoadGameBtn.IsVisible ) MyLogger.logger.LogInformation("C��������� �������, ���������� ������.");
        else MyLogger.logger.LogInformation("C��������� �� �������.");
#endif
    }
    //------------------------------------------------------------------------------------------------------------------------------
    private async void LoadGameBtn_Clicked(object sender, EventArgs e)
    {
        if (!isBusy)
        {
            isBusy = true;
            �haracter�haracteristics �haracter�haracteristics = loadGameSoloPage.GetCurrentCharacterToStruct();
            await Navigation.PushModalAsync(new LoadGamePage());
            isBusy = false;
#if DEBUG
            MyLogger.logger.LogInformation("������� �� �������� �������� ���� - �������.");
#endif
            return;
        }
#if DEBUG
        MyLogger.logger.LogInformation("������ �������� �������� �������� ���� - ������!");
#endif
    }
    private async void NewGameBtn_Clicked(object sender, EventArgs e)
    {
        if (!isBusy)
        {
            isBusy = true;
            loadingIndicator.IsRunning = true;
            await Navigation.PushModalAsync(new CharacterCreationPage(LoadGameBtn));
            loadingIndicator.IsRunning = false;
            isBusy = false;
#if DEBUG
            MyLogger.logger.LogInformation("������� �� �������� �������� ��������� - �������.");
#endif
            return;
        }
#if DEBUG
        MyLogger.logger.LogInformation("������ �������� �������� �������� ��������� - ������!");
#endif
    }
    private async void BackBtn_Clicked(object sender, EventArgs e)
    {
        if (!isBusy)
        {
            isBusy = true;
            await Navigation.PopModalAsync();
            isBusy = false;
#if DEBUG
            MyLogger.logger.LogInformation("������� �� �������� ���� - �������.");
#endif
            return;
        }
#if DEBUG
        MyLogger.logger.LogInformation("������ �������� �������� ���� - ������!");
#endif
    }
    //------------------------------------------------------------------------------------------------------------------------------
}
//----------------------------------------------------------------------------------------------------------------------------------