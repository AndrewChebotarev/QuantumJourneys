﻿//Русский язык для страница "Настройки"
//--------------------------------------------------------------------------------------------------------------------------------------
namespace QuantumJourneys.Pages.SettingsPage.Language
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
            languagePicker.Items.Add("Английский");
            languagePicker.Items.Add("Русский");
            languagePicker.SelectedIndex = 1;
            settingsPage.oldSelectedIndexLanguage = languagePicker.SelectedIndex;
            languagePicker.SelectedIndexChanged += settingsPage.SelectedIndexLanguagePicker;

            Label soundLabel = (Label)settingsPage.FindByName("soundLabel");
            soundLabel.Text = "Громкость:";

            Slider soundSlider = (Slider)settingsPage.FindByName("soundSlider");
            soundSlider.Value = 200;

            Button ExitBtn = (Button)settingsPage.FindByName("ExitBtn");
            ExitBtn.Text = "Назад";
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
    //----------------------------------------------------------------------------------------------------------------------------------
}
//--------------------------------------------------------------------------------------------------------------------------------------
