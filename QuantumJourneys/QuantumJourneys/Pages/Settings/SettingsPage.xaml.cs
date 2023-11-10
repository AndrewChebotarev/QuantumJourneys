//Работа со страницей настроек
//----------------------------------------------------------------------------------------------------------------------------------------------

namespace QuantumJourneys.Pages.Settings;

//----------------------------------------------------------------------------------------------------------------------------------------------

public partial class SettingsPage : ContentPage
{
    //------------------------------------------------------------------------------------------------------------------------------------------

    public int oldSelectedIndexLanguage;
    private IAudioPlayer audioPlayer;
    private bool IsInitSound = false;

    //------------------------------------------------------------------------------------------------------------------------------------------
    public SettingsPage(string language, IAudioPlayer audioPlayer)
	{
		InitializeComponent(); 
        InitAudio(audioPlayer);
        InitLanguage(language);
    }
    //------------------------------------------------------------------------------------------------------------------------------------------
    private void InitAudio(IAudioPlayer audioPlayer)
    {
        this.audioPlayer = audioPlayer;
        soundSlider.Value = audioPlayer.Volume;
        IsInitSound = true;
    }
    private void InitLanguage(string language)
    {
        switch (language)
        {
            case "Ru":
                new Settings_Ru(this);
                break;

            case "En":
                new Settings_En(this);
                break;

            default:
                new Settings_En(this);
                break;
        }
    }
    //------------------------------------------------------------------------------------------------------------------------------------------
    public void SelectedIndexLanguagePicker(object sender, EventArgs eventArgs)
    {
        if (languagePicker.SelectedIndex == oldSelectedIndexLanguage) return;
        else ChoiceLanguage();
    }
    private async void BackBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync(true);
    }
    //------------------------------------------------------------------------------------------------------------------------------------------
    private void ChoiceLanguage()
    {
        if (languagePicker.SelectedIndex == 0) ChangeLanguageEn();
        else if (languagePicker.SelectedIndex == 1) ChangeLanguageRu();
        else ChangeLanguageEn();
    }
    //------------------------------------------------------------------------------------------------------------------------------------------
    private async void ChangeLanguageEn()
    {
        bool result = await DisplayAlert("Применить изменения", "Для изменения нужно перезагрузить приложение! Вы согласны?", "Да", "Нет");

        if (result) 
        {
            ReWriteTXTSettingFile("En");
            App.Current.Quit();
        }
        else languagePicker.SelectedIndex = oldSelectedIndexLanguage;
    }
    private async void ChangeLanguageRu()
    {
        bool result = await DisplayAlert("Apply changes", "To change you need to restart the application! Do you agree?", "Yes", "No");

        if (result) 
        {
            ReWriteTXTSettingFile("Ru");
            App.Current.Quit();
        }
        else languagePicker.SelectedIndex = oldSelectedIndexLanguage;
    }
    //------------------------------------------------------------------------------------------------------------------------------------------
    private async void OnSoundValueChanged(object sender, EventArgs e)
    {
        if (IsInitSound)
        {
            await ChangeSettingSoundValue();
            audioPlayer.Volume = soundSlider.Value;
        }
    }
    //------------------------------------------------------------------------------------------------------------------------------------------
    private void ReWriteTXTSettingFile(string newLanguage)
    {
        string[] lines = ReadAllLinesSettingsFile();
        lines[0] = newLanguage;
        ReWriteSettingsFile(lines);
    }
    private Task ChangeSettingSoundValue()
    {
        string[] lines = ReadAllLinesSettingsFile();
        lines[1] = ChangeSettingLine(lines);
        ReWriteSettingsFile(lines);
        return Task.CompletedTask;
    }

    //------------------------------------------------------------------------------------------------------------------------------------------
    private string[] ReadAllLinesSettingsFile() => File.ReadAllLines(Path.Combine(GetFolderPath(), "setting.txt"));
    private string ChangeSettingLine(string[] lines) => audioPlayer.Volume.ToString();
    private void ReWriteSettingsFile(string[] lines)
    {
        File.WriteAllLines(Path.Combine(GetFolderPath(), "setting.txt"), lines);
    }
    //------------------------------------------------------------------------------------------------------------------------------------------
    private string GetFolderPath()
    {
        return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    }
    //------------------------------------------------------------------------------------------------------------------------------------------
}
//----------------------------------------------------------------------------------------------------------------------------------------------