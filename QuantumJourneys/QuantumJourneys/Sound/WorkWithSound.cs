//Класс для работы с аудио и звуками
//------------------------------------------------------------------------------------------------------------------------------------------
namespace QuantumJourneys.Sound
{
    //--------------------------------------------------------------------------------------------------------------------------------------
    public static class WorkWithSound
    {
        //----------------------------------------------------------------------------------------------------------------------------------
        public static async Task InitNewAudioPlayer(string sound, bool isLoop)
        {
            WorkingAudioPlayer.audioPlayer = WorkingAudioPlayer.audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(sound));
            WorkingAudioPlayer.audioPlayer.Volume = WorkingAudioPlayer.valume;
            WorkingAudioPlayer.audioPlayer.Loop = isLoop;
            WorkingAudioPlayer.audioPlayer.Play();
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        public static async Task StopAudioPlayer()
        {
            while (WorkingAudioPlayer.audioPlayer.Volume > 0)
            {
                WorkingAudioPlayer.audioPlayer.Volume -= 0.1;
                await Task.Delay(100);
            }
            WorkingAudioPlayer.audioPlayer.Stop();
            WorkingAudioPlayer.audioPlayer.Dispose();
        }
        //----------------------------------------------------------------------------------------------------------------------------------
    }
    //--------------------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------------------
