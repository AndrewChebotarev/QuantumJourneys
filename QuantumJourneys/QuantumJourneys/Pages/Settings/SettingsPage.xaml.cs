//Работа со страницей настроек
//----------------------------------------------------------------------------------------------------------------------------------------------

namespace QuantumJourneys.Pages.Settings;

//----------------------------------------------------------------------------------------------------------------------------------------------

public partial class SettingsPage : ContentPage
{
    //------------------------------------------------------------------------------------------------------------------------------------------

    private bool isBusy = false;
    private bool IsInitSound = false;
    MainPage mainPage;

    //------------------------------------------------------------------------------------------------------------------------------------------
    public SettingsPage(MainPage mainPage)
	{
#if DEBUG
        MyLogger.logger.LogInformation("Начало инициализации страницы настроек.");
#endif
        InitializeComponent();
        this.mainPage = mainPage;
        InitAudio();
        InitLanguage();
#if DEBUG
        MyLogger.logger.LogInformation("Конец инициализации страницы настроек.");
#endif
    }
    //------------------------------------------------------------------------------------------------------------------------------------------
    private void InitAudio()
    {
#if DEBUG
        MyLogger.logger.LogInformation("Получение аудиоплеера для работы.");
#endif
        soundSlider.Value = WorkingAudioPlayer.audioPlayer.Volume;
        IsInitSound = true;
    }
    private void InitLanguage()
    {
#if DEBUG
        MyLogger.logger.LogInformation("Начало инициализации языка для страницы настроек.");
#endif
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
#if DEBUG
        MyLogger.logger.LogInformation("Изменение языка игры.");
#endif
        ChoiceLanguage();
    }
    private async void BackBtn_Clicked(object sender, EventArgs e)
    {
        if (!isBusy)
        {
            isBusy = true;
            await Navigation.PopModalAsync();
            isBusy = false;
#if DEBUG
            MyLogger.logger.LogInformation("Переход на страницу меню - успешен.");
#endif
            return;
        }
#if DEBUG
        MyLogger.logger.LogInformation("Кнопка открытия страницы меню - занята!");
#endif
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
#if DEBUG
            MyLogger.logger.LogInformation("Изменение громкости аудио в игре.");
#endif
            await ChangeSettingSoundValue();
            WorkingAudioPlayer.valume = soundSlider.Value;
            WorkingAudioPlayer.audioPlayer.Volume = WorkingAudioPlayer.valume;
        }
    }
    //------------------------------------------------------------------------------------------------------------------------------------------
    private void ReWriteTXTSettingFile(string newLanguage)
    {
#if DEBUG
        MyLogger.logger.LogInformation("Изменение языка игры для файла настроек.");
#endif
        string[] lines = ReadAllLinesSettingsFile();
        lines[0] = newLanguage;
        ReWriteSettingsFile(lines);
    }
    private Task ChangeSettingSoundValue()
    {
#if DEBUG
        MyLogger.logger.LogInformation("Изменение громкости аудио игры для файла настроек.");
#endif
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
#if DEBUG
        MyLogger.logger.LogInformation("Файл перезаписан.");
#endif
    }
    //------------------------------------------------------------------------------------------------------------------------------------------
    private string GetFolderPath()
    {
        return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    }
    //------------------------------------------------------------------------------------------------------------------------------------------
}
//----------------------------------------------------------------------------------------------------------------------------------------------