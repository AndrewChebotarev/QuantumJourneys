//Класс для работы с миниигрой
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
            MyLogger.logger.LogInformation("Начало инициализации мини игры.");
#endif
            InitializeComponent();
            this.audio = audio;
#if DEBUG
            MyLogger.logger.LogInformation("Конец инициализации мини игры.");
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
                MyLogger.logger.LogInformation("Переход на страницу мини игра - успешен.");
#endif
                return;
            }
#if DEBUG
            MyLogger.logger.LogInformation("Кнопка открытия страницы мини игра - занята!");
#endif
        }
        //--------------------------------------------------------------------------------------------------------------------------
    }
    //------------------------------------------------------------------------------------------------------------------------------
}
//----------------------------------------------------------------------------------------------------------------------------------