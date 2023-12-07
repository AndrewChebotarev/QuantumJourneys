//����� ��� ������ �� �����������
//--------------------------------------------------------------------------------------------------------------------------------------

namespace QuantumJourneys.Pages.Statistics;

//--------------------------------------------------------------------------------------------------------------------------------------
public partial class StatisticsPage : ContentPage
{
    //----------------------------------------------------------------------------------------------------------------------------------
    public StatisticsPage()
	{
#if DEBUG
        MyLogger.logger.LogInformation("������ ������������� �������� ����������.");
#endif
        InitializeComponent();
#if DEBUG
        MyLogger.logger.LogInformation("����� ������������� �������� ����������.");
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
            MyLogger.logger.LogInformation("������� �� �������� ���� - �������.");
#endif
            return;
        }
#if DEBUG
        MyLogger.logger.LogInformation("������ �������� �������� ���� - ������!");
#endif
    }
    //----------------------------------------------------------------------------------------------------------------------------------
}
//--------------------------------------------------------------------------------------------------------------------------------------