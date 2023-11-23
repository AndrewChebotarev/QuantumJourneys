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
            if (!Directory.Exists(folderPath))
            {
#if DEBUG
                MyLogger.logger.LogInformation("Папка для хранения информации не найдена, попытка создания папки.");
#endif
                Directory.CreateDirectory(folderPath);
#if DEBUG
                MyLogger.logger.LogInformation("Папка для хранения информации создана.");
#endif
            }
#if DEBUG
            MyLogger.logger.LogInformation("Папка для хранения информации найдена.");
#endif
        }
        private void CheckSettingsFile()
        {
            if (!File.Exists(Path.Combine(folderPath, "setting.txt")))
            {
#if DEBUG
                MyLogger.logger.LogInformation("Файл для хранения информации о настройках не найден, попытка создания папки и записи информации поумолчанию.");
#endif
                using (FileStream fs = File.Create(Path.Combine(folderPath, "setting.txt"))) { }
                using (StreamWriter writer = new StreamWriter(Path.Combine(folderPath, "setting.txt"))) { writer.WriteLine("En"); writer.WriteLine("1"); }
#if DEBUG
                MyLogger.logger.LogInformation("Файл для хранения информации о настройках создан, информация записана.");
#endif
            }
#if DEBUG
            MyLogger.logger.LogInformation("Файл для хранения информации о настройка найден.");
#endif
        }
        //------------------------------------------------------------------------------------------------------------------------------
        private void GetCurrentSettings(MainPage mainPage)
        {
            using (StreamReader reader = new StreamReader(Path.Combine(folderPath, "setting.txt")))
            {
#if DEBUG
                MyLogger.logger.LogInformation("Начало считывания информации с файла настроек.");
#endif
                ReadCurrentLanguage(reader);
                SettingCurrentLanguage(mainPage);

                string ValueSoundString = ReadCurrentValueSound(reader);
                SettingCurrentValueSound(GetCurrentValueSoundInt(ValueSoundString));
#if DEBUG
                MyLogger.logger.LogInformation("Конец считывания информации с файла настроек.");
#endif
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------
        private void ReadCurrentLanguage(StreamReader reader)
        {
            SelectLanguage.language = reader.ReadLine().Replace("\n", "");
#if DEBUG
            MyLogger.logger.LogInformation($"Считывания языка - {SelectLanguage.language}");
#endif
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
        private string ReadCurrentValueSound(StreamReader reader)
        {
            string currentValueSound = reader.ReadLine().Replace("\n", "");
#if DEBUG
            MyLogger.logger.LogInformation($"Считывания значения громкости звука - {currentValueSound}");
#endif
            return currentValueSound;
        }
        private double GetCurrentValueSoundInt(string value) => double.Parse(value);
        private void SettingCurrentValueSound(double currentValue)
        {
            WorkingAudioPlayer.valume = currentValue;
            WorkingAudioPlayer.audioPlayer.Volume = WorkingAudioPlayer.valume;
#if DEBUG
            MyLogger.logger.LogInformation("Установка значений для игры.");
#endif
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
    //----------------------------------------------------------------------------------------------------------------------------------
}
//--------------------------------------------------------------------------------------------------------------------------------------
