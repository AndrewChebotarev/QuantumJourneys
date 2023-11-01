//Чтение выбранного языка приложения и установка в приложении
//--------------------------------------------------------------------------------------------------------------------------------------
namespace QuantumJourneys.Pages.MenuPage.Language
{
    //----------------------------------------------------------------------------------------------------------------------------------
    public class SettingsText
    {
        //------------------------------------------------------------------------------------------------------------------------------

        static private string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        //------------------------------------------------------------------------------------------------------------------------------
        public SettingsText(MainPage mainPage) 
        {
            CheckFolderPath();
            CheckLangFile();
            GetCurrentLanguage(mainPage);
        }
        //------------------------------------------------------------------------------------------------------------------------------
        private void CheckFolderPath()
        {
            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);
        }
        private void CheckLangFile()
        {
            if (!File.Exists(Path.Combine(folderPath, "language.txt")))
            {
                using (FileStream fs = File.Create(Path.Combine(folderPath, "language.txt"))) { }
                using (StreamWriter writer = new StreamWriter(Path.Combine(folderPath, "language.txt"))) { writer.WriteLine("En"); }
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------
        private void GetCurrentLanguage(MainPage mainPage)
        {
            using (StreamReader reader = new StreamReader(Path.Combine(folderPath, "language.txt")))
            {
                SettingCurrentLanguage(ReadCurrentLanguage(reader), mainPage);
            }
        }
        private string ReadCurrentLanguage(StreamReader reader) => reader.ReadToEnd().Replace("\n", "");
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
    }
    //----------------------------------------------------------------------------------------------------------------------------------
}
//--------------------------------------------------------------------------------------------------------------------------------------
