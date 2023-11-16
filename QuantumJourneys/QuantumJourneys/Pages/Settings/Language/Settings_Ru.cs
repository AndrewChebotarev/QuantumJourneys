//Русский язык для страница "Настройки"
//--------------------------------------------------------------------------------------------------------------------------------------
namespace QuantumJourneys.Pages.Settings.Language
{
    //----------------------------------------------------------------------------------------------------------------------------------
    public class Settings_Ru
    {
        //------------------------------------------------------------------------------------------------------------------------------
        public Settings_Ru(SettingsPage settingsPage) 
        {
            Label settingLabel = (Label)settingsPage.FindByName("settingLabel");
            settingLabel.Text = "Настройки";

            Label languageLabel = (Label)settingsPage.FindByName("languageLabel");
            languageLabel.Text = "Язык:";

            Picker languagePicker = (Picker)settingsPage.FindByName("languagePicker");
            languagePicker.Title = "Выберите язык:";
            languagePicker.SelectedIndex = 1;
            languagePicker.SelectedIndexChanged += settingsPage.SelectedIndexLanguagePicker;

            Label soundLabel = (Label)settingsPage.FindByName("soundLabel");
            soundLabel.Text = "Громкость:";

            Slider soundSlider = (Slider)settingsPage.FindByName("soundSlider");

            Button ExitBtn = (Button)settingsPage.FindByName("BackBtn");
            ExitBtn.Text = "Назад";
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
    //----------------------------------------------------------------------------------------------------------------------------------
}
//--------------------------------------------------------------------------------------------------------------------------------------
