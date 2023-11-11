//Класс для работы со страницей выбора новой игры или загрузить игру
//----------------------------------------------------------------------------------------------------------------------------------

namespace QuantumJourneys.Pages;

//----------------------------------------------------------------------------------------------------------------------------------
public partial class NewOrLoadGameSoloPage : ContentPage
{
    //------------------------------------------------------------------------------------------------------------------------------

    private string language;
    private LoadGameSoloPage loadGameSoloPage;

    //------------------------------------------------------------------------------------------------------------------------------
    public NewOrLoadGameSoloPage(string currentLanguage)
	{
		InitializeComponent();
        InitLanguage(currentLanguage);
        InitLoadGameBtn();
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
    private void InitLoadGameBtn()
    {
        LoadGameSoloPage loadGameSoloPage = new();
        this.loadGameSoloPage = loadGameSoloPage;
        LoadGameBtn.IsVisible = loadGameSoloPage.CheckOldGame();
    }
    //------------------------------------------------------------------------------------------------------------------------------
    private async void LoadGameBtn_Clicked(object sender, EventArgs e)
    {
        СharacterСharacteristics сharacterСharacteristics = loadGameSoloPage.GetCurrentCharacterToStruct();
        await Navigation.PushModalAsync(new LoadGamePage());
    }
    private async void NewGameBtn_Clicked(object sender, EventArgs e)
    {
        loadingIndicator.IsRunning = true;
        await Navigation.PushModalAsync(new CharacterCreationPage(language, LoadGameBtn));
        loadingIndicator.IsRunning = false;
    }
    private async void BackBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
    //------------------------------------------------------------------------------------------------------------------------------
}
//----------------------------------------------------------------------------------------------------------------------------------