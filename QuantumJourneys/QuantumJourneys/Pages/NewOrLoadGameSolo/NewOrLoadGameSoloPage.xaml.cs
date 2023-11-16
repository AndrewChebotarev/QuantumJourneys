//Класс для работы со страницей выбора новой игры или загрузить игру
//----------------------------------------------------------------------------------------------------------------------------------

namespace QuantumJourneys.Pages;

//----------------------------------------------------------------------------------------------------------------------------------
public partial class NewOrLoadGameSoloPage : ContentPage
{
    //------------------------------------------------------------------------------------------------------------------------------

    private LoadGameSoloPage loadGameSoloPage;

    //------------------------------------------------------------------------------------------------------------------------------
    public NewOrLoadGameSoloPage()
	{
		InitializeComponent();
        InitLanguage();
        InitLoadGameBtn();
	}
    //------------------------------------------------------------------------------------------------------------------------------
    private void InitLanguage()
    {
        switch (SelectLanguage.language)
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
        await Navigation.PushModalAsync(new CharacterCreationPage(LoadGameBtn));
        loadingIndicator.IsRunning = false;
    }
    private async void BackBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
    //------------------------------------------------------------------------------------------------------------------------------
}
//----------------------------------------------------------------------------------------------------------------------------------