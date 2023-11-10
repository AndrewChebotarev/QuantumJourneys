//Чтение выбранного языка приложения и установка в приложении
//--------------------------------------------------------------------------------------------------------------------------------------
namespace QuantumJourneys.Pages.Menu.Language
{
    //----------------------------------------------------------------------------------------------------------------------------------
    public class SettingsInit
    {
        //------------------------------------------------------------------------------------------------------------------------------

        IAudioPlayer audioPlayer;
        static private string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        //------------------------------------------------------------------------------------------------------------------------------
        public SettingsInit(MainPage mainPage, IAudioPlayer audioPlayer) 
        {
            this.audioPlayer = audioPlayer;
            CheckFolderPath();
            CheckSettingsFile();
            GetCurrentSettings(mainPage);
        }
        //------------------------------------------------------------------------------------------------------------------------------
        private void CheckFolderPath()
        {
            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);
        }
        private void CheckSettingsFile()
        {
            if (!File.Exists(Path.Combine(folderPath, "setting.txt")))
            {
                using (FileStream fs = File.Create(Path.Combine(folderPath, "setting.txt"))) { }
                using (StreamWriter writer = new StreamWriter(Path.Combine(folderPath, "setting.txt"))) { writer.WriteLine("En"); writer.WriteLine("1"); }
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------
        private void GetCurrentSettings(MainPage mainPage)
        {
            using (StreamReader reader = new StreamReader(Path.Combine(folderPath, "setting.txt")))
            {
                SettingCurrentLanguage(ReadCurrentLanguage(reader), mainPage);

                string ValueSoundString = ReadCurrentValueSound(reader);
                SettingCurrentValueSound(GetCurrentValueSoundInt(ValueSoundString), mainPage);
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------
        private string ReadCurrentLanguage(StreamReader reader) => reader.ReadLine().Replace("\n", "");
        private void SettingCurrentLanguage(string currentLanguage, MainPage mainPage)
        {
            switch (currentLanguage)
            {
                case "Ru":
                    mainPage.currentLanguage = "Ru";
                    new Menu_Ru(mainPage);
                    break;

                case "En":
                    mainPage.currentLanguage = "En";
                    new Menu_En(mainPage);
                    break;

                default:
                    mainPage.currentLanguage = "En";
                    new Menu_En(mainPage);
                    break;
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------
        private string ReadCurrentValueSound(StreamReader reader) => reader.ReadLine().Replace("\n", "");
        private double GetCurrentValueSoundInt(string value) => double.Parse(value);
        private void SettingCurrentValueSound(double currentValue, MainPage mainPage)
        {
            audioPlayer.Volume = currentValue;
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
    //----------------------------------------------------------------------------------------------------------------------------------
}
//--------------------------------------------------------------------------------------------------------------------------------------
