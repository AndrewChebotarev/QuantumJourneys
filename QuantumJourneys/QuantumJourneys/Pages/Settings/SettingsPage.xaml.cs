//Работа со страницей настроек
//----------------------------------------------------------------------------------------------------------------------------------------------

namespace QuantumJourneys.Pages.Settings;

//----------------------------------------------------------------------------------------------------------------------------------------------

public partial class SettingsPage : ContentPage
{
    //------------------------------------------------------------------------------------------------------------------------------------------

    private bool IsInitSound = false;
    MainPage mainPage;

    //------------------------------------------------------------------------------------------------------------------------------------------
    public SettingsPage(MainPage mainPage)
	{
		InitializeComponent();
        this.mainPage = mainPage;
        InitAudio();
        InitLanguage();
    }
    //------------------------------------------------------------------------------------------------------------------------------------------
    private void InitAudio()
    {
        soundSlider.Value = WorkingAudioPlayer.audioPlayer.Volume;
        IsInitSound = true;
    }
    private void InitLanguage()
    {
        switch (SelectLanguage.language)
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
        ChoiceLanguage();
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
    private void ChangeLanguageEn()
    {
        ReWriteTXTSettingFile("En");
        SelectLanguage.language = "En";
        new Settings_En(this);
        new Menu_En(mainPage);
    }
    private void ChangeLanguageRu()
    {
        ReWriteTXTSettingFile("Ru");
        SelectLanguage.language = "Ru";
        new Settings_Ru(this);
        new Menu_Ru(mainPage);
    }
    //------------------------------------------------------------------------------------------------------------------------------------------
    private async void OnSoundValueChanged(object sender, EventArgs e)
    {
        if (IsInitSound)
        {
            await ChangeSettingSoundValue();
            WorkingAudioPlayer.audioPlayer.Volume = soundSlider.Value;
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
    private string ChangeSettingLine(string[] lines) => WorkingAudioPlayer.audioPlayer.Volume.ToString();
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