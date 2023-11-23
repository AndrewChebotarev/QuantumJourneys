//Английский язык для страницы "Настройки"
//------------------------------------------------------------------------------------------------------------------------------------------
namespace QuantumJourneys.Pages.Settings.Language
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
            languagePicker.SelectedIndex = 0;
            languagePicker.SelectedIndexChanged += settingsPage.SelectedIndexLanguagePicker;

            Label soundLabel = (Label)settingsPage.FindByName("soundLabel");
            soundLabel.Text = "Volume:";

            Slider soundSlider = (Slider)settingsPage.FindByName("soundSlider");

            Button ExitBtn = (Button)settingsPage.FindByName("BackBtn");
            ExitBtn.Text = "Back";

#if DEBUG
            MyLogger.logger.LogInformation("Инициализация текста для UI английский - завершена.");
#endif
        }
        //----------------------------------------------------------------------------------------------------------------------------------
    }
    //--------------------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------------------
