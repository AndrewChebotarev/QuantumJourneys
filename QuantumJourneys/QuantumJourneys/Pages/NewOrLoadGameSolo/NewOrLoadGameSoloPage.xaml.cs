//Класс для работы со страницей выбора новой игры или загрузить игру
//----------------------------------------------------------------------------------------------------------------------------------

namespace QuantumJourneys.Pages;

//----------------------------------------------------------------------------------------------------------------------------------
public partial class NewOrLoadGameSoloPage : ContentPage
{
    //------------------------------------------------------------------------------------------------------------------------------

    private string language;

    //------------------------------------------------------------------------------------------------------------------------------
    public NewOrLoadGameSoloPage(string currentLanguage)
	{
		InitializeComponent();
        InitLanguage(currentLanguage);
	}
    //------------------------------------------------------------------------------------------------------------------------------
    private void InitLanguage(string language)
    {
        switch (language)
        {
            case "Ru":
                new NewOrLoadGameSolo_Ru(this);
                break;

            case "En":
                new NewOrLoadGameSolo_En(this);
                break;

            default:
                new NewOrLoadGameSolo_En(this);
                break;
        }

        this.language = language;
    }
    //------------------------------------------------------------------------------------------------------------------------------
    private async void NewGameBtn_Clicked(object sender, EventArgs e)
    {
        loadingIndicator.IsRunning = true;
        await Navigation.PushModalAsync(new CharacterCreationPage(language));
        loadingIndicator.IsRunning = false;
    }
    private async void LoadGameBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new LoadGamePage());
    }
    private async void BackBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
    //------------------------------------------------------------------------------------------------------------------------------
}
//----------------------------------------------------------------------------------------------------------------------------------