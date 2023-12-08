//����� ��� ������ � ���������
//----------------------------------------------------------------------------------------------------------------------------------

namespace QuantumJourneys.Pages.MiniGame.OpenDoor
{
    //------------------------------------------------------------------------------------------------------------------------------
    public partial class MiniGame_OpenDoor : ContentPage
    {

        private string audio;

        //--------------------------------------------------------------------------------------------------------------------------
        public MiniGame_OpenDoor(string audio)
        {
#if DEBUG
            MyLogger.logger.LogInformation("������ ������������� ���� ����.");
#endif
            InitializeComponent();
            this.audio = audio;
#if DEBUG
            MyLogger.logger.LogInformation("����� ������������� ���� ����.");
#endif
        }
        //--------------------------------------------------------------------------------------------------------------------------
        private async void BackBtn_Clicked(object sender, EventArgs e)
        {
            if (!CheckProcessBusy.isProcessBusy)
            {
                CheckProcessBusy.isProcessBusy = true;
                await WorkWithSound.StopAudioPlayer();
                await WorkWithSound.InitNewAudioPlayer(audio, true);
                await Navigation.PopModalAsync();
                CheckProcessBusy.isProcessBusy = false;
#if DEBUG
                MyLogger.logger.LogInformation("������� �� �������� ���� ���� - �������.");
#endif
                return;
            }
#if DEBUG
            MyLogger.logger.LogInformation("������ �������� �������� ���� ���� - ������!");
#endif
        }
        //--------------------------------------------------------------------------------------------------------------------------
    }
    //------------------------------------------------------------------------------------------------------------------------------
}
//----------------------------------------------------------------------------------------------------------------------------------