//Работа со страницей настроек
//----------------------------------------------------------------------------------------------------------------------------------------------

namespace QuantumJourneys.Pages.SettingsPage;

//----------------------------------------------------------------------------------------------------------------------------------------------

public partial class SettingsPage : ContentPage
{
    //------------------------------------------------------------------------------------------------------------------------------------------

    public int oldSelectedIndexLanguage;

    //------------------------------------------------------------------------------------------------------------------------------------------
    public SettingsPage(string language)
	{
		InitializeComponent();
        InitLanguage(language);
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
        await Navigation.PopModalAsync(false);
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
        bool result = await DisplayAlert("Apply changes", "To change you need to restart the application! Do you agree?", "Yes", "No");

        if (result) 
        {
            ReWriteTXTSettingFile("En");
            App.Current.Quit();
        }
        else languagePicker.SelectedIndex = oldSelectedIndexLanguage;
    }
    private async void ChangeLanguageRu()
    {
        bool result = await DisplayAlert("Применить изменения", "Для изменения нужно перезагрузить приложение! Вы согласны?", "Да", "Нет");

        if (result) 
        {
            ReWriteTXTSettingFile("Ru");
            App.Current.Quit();
        }
        else languagePicker.SelectedIndex = oldSelectedIndexLanguage;
    }
    //------------------------------------------------------------------------------------------------------------------------------------------
    private void ReWriteTXTSettingFile(string newLanguage)
    {
        string folderPath = GetFolderPath();

        using (StreamWriter writer = new StreamWriter(Path.Combine(folderPath, "language.txt")))
        {
            writer.WriteLine(newLanguage);
        }
    }
    //------------------------------------------------------------------------------------------------------------------------------------------
    private string GetFolderPath()
    {
        return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    }
    //------------------------------------------------------------------------------------------------------------------------------------------
}
//----------------------------------------------------------------------------------------------------------------------------------------------