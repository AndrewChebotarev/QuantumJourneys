//Чтение выбранного языка приложения и уровня звука - установка в приложении
//--------------------------------------------------------------------------------------------------------------------------------------
namespace QuantumJourneys.Pages.Menu.Language
{
    //----------------------------------------------------------------------------------------------------------------------------------
    public class SettingsInit
    {
        //------------------------------------------------------------------------------------------------------------------------------

        static private string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        //------------------------------------------------------------------------------------------------------------------------------
        public SettingsInit(MainPage mainPage) 
        {
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
                ReadCurrentLanguage(reader);
                SettingCurrentLanguage(mainPage);

                string ValueSoundString = ReadCurrentValueSound(reader);
                SettingCurrentValueSound(GetCurrentValueSoundInt(ValueSoundString));
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------
        private void ReadCurrentLanguage(StreamReader reader)
        {
            SelectLanguage.language = reader.ReadLine().Replace("\n", "");
        }
        private void SettingCurrentLanguage( MainPage mainPage)
        {
            switch (SelectLanguage.language)
            {
                case "Ru":
                    SelectLanguage.language = "Ru";
                    new Menu_Ru(mainPage);
                    break;

                case "En":
                    SelectLanguage.language = "En";
                    new Menu_En(mainPage);
                    break;

                default:
                    SelectLanguage.language = "En";
                    new Menu_En(mainPage);
                    break;
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------
        private string ReadCurrentValueSound(StreamReader reader) => reader.ReadLine().Replace("\n", "");
        private double GetCurrentValueSoundInt(string value) => double.Parse(value);
        private void SettingCurrentValueSound(double currentValue)
        {
            WorkingAudioPlayer.audioPlayer.Volume = currentValue;
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
    //----------------------------------------------------------------------------------------------------------------------------------
}
//--------------------------------------------------------------------------------------------------------------------------------------
