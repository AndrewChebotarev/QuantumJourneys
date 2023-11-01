//Английский язык для страницы "Настройки"
//------------------------------------------------------------------------------------------------------------------------------------------
namespace QuantumJourneys.Pages.SettingsPage.Language
{
    //--------------------------------------------------------------------------------------------------------------------------------------
    public class Settings_En
    {
        //----------------------------------------------------------------------------------------------------------------------------------
        public Settings_En(SettingsPage settingsPage) 
        {
            Label settingLabel = (Label)settingsPage.FindByName("settingLabel");
            settingLabel.Text = "Settings";

            Label languageLabel = (Label)settingsPage.FindByName("languageLabel");
            languageLabel.Text = "Language:";

            Picker languagePicker = (Picker)settingsPage.FindByName("languagePicker");
            languagePicker.Title = "Choose language:";
            languagePicker.Items.Add("English");
            languagePicker.Items.Add("Russian");
            languagePicker.SelectedIndex = 0;
            settingsPage.oldSelectedIndexLanguage = languagePicker.SelectedIndex;
            languagePicker.SelectedIndexChanged += settingsPage.SelectedIndexLanguagePicker;

            Label soundLabel = (Label)settingsPage.FindByName("soundLabel");
            soundLabel.Text = "Volume:";

            Slider soundSlider = (Slider)settingsPage.FindByName("soundSlider");
            soundSlider.Value = 200;

            Button ExitBtn = (Button)settingsPage.FindByName("ExitBtn");
            ExitBtn.Text = "Back";
        }
        //----------------------------------------------------------------------------------------------------------------------------------
    }
    //--------------------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------------------
