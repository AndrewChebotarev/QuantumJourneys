namespace QuantumJourneys.Sound
{
    public static class WorkWithSound
    {
        public static async Task InitNewAudioPlayer(IAudioManager audioManager, string sound)
        {
            WorkingAudioPlayer.audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(sound));
            WorkingAudioPlayer.audioPlayer.Volume = new();
            WorkingAudioPlayer.audioPlayer.Loop = true;
            WorkingAudioPlayer.audioPlayer.Play();
        }
        public static void StopAudioPlayer()
        {
            while (WorkingAudioPlayer.audioPlayer.Volume > 0) WorkingAudioPlayer.audioPlayer.Volume -= 0.01;
            WorkingAudioPlayer.audioPlayer.Stop(); 
        }
    }
}
