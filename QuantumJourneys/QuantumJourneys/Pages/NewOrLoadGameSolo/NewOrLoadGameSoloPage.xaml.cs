//Класс для работы со страницей выбора новой игры или загрузить игру
//----------------------------------------------------------------------------------------------------------------------------------

namespace QuantumJourneys.Pages;

//----------------------------------------------------------------------------------------------------------------------------------
public partial class NewOrLoadGameSoloPage : ContentPage
{
    //------------------------------------------------------------------------------------------------------------------------------

    private bool isBusy = false;
    private LoadGameSoloPage loadGameSoloPage;

    //------------------------------------------------------------------------------------------------------------------------------
    public NewOrLoadGameSoloPage()
	{
#if DEBUG
        MyLogger.logger.LogInformation("Начало инициализации страницы выбора загрузки или новой игры для одиночного режима.");
#endif
        InitializeComponent();
        InitLanguage();
        InitLoadGameBtn();
#if DEBUG
        MyLogger.logger.LogInformation("Конец инициализации страницы выбора загрузки или новой игры для одиночного режима.");
#endif
    }
    //------------------------------------------------------------------------------------------------------------------------------
    private void InitLanguage()
    {
#if DEBUG
        MyLogger.logger.LogInformation("Начало инициализации языка для страницы выбора загрузки или новой игры для одиночного режима.");
#endif
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
#if DEBUG
        MyLogger.logger.LogInformation("Начало проверки на сохранение.");
#endif
        LoadGameSoloPage loadGameSoloPage = new();
        this.loadGameSoloPage = loadGameSoloPage;
        LoadGameBtn.IsVisible = loadGameSoloPage.CheckOldGame();

#if DEBUG
        if (LoadGameBtn.IsVisible ) MyLogger.logger.LogInformation("Cохранение найдено, отображаем кнопку.");
        else MyLogger.logger.LogInformation("Cохранение не найдено.");
#endif
    }
    //------------------------------------------------------------------------------------------------------------------------------
    private async void LoadGameBtn_Clicked(object sender, EventArgs e)
    {
        if (!isBusy)
        {
            isBusy = true;
            СharacterСharacteristics сharacterСharacteristics = loadGameSoloPage.GetCurrentCharacterToStruct();
            await Navigation.PushModalAsync(new LoadGamePage());
            isBusy = false;
#if DEBUG
            MyLogger.logger.LogInformation("Переход на страницу загрузки игры - успешен.");
#endif
            return;
        }
#if DEBUG
        MyLogger.logger.LogInformation("Кнопка открытия страницы зыгрузки игры - занята!");
#endif
    }
    private async void NewGameBtn_Clicked(object sender, EventArgs e)
    {
        if (!isBusy)
        {
            isBusy = true;
            loadingIndicator.IsRunning = true;
            await Navigation.PushModalAsync(new CharacterCreationPage(LoadGameBtn));
            loadingIndicator.IsRunning = false;
            isBusy = false;
#if DEBUG
            MyLogger.logger.LogInformation("Переход на страницу создание персонажа - успешен.");
#endif
            return;
        }
#if DEBUG
        MyLogger.logger.LogInformation("Кнопка открытия страницы создания персонажа - занята!");
#endif
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
    //------------------------------------------------------------------------------------------------------------------------------
}
//----------------------------------------------------------------------------------------------------------------------------------