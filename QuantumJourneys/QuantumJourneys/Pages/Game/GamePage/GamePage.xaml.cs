//Класс для реализации основной игры
//------------------------------------------------------------------------------------------------------------------------------

namespace QuantumJourneys.Pages.Game;

//------------------------------------------------------------------------------------------------------------------------------
public partial class GamePage : ContentPage
{
    //--------------------------------------------------------------------------------------------------------------------------

    private bool isWait = false;
    private bool isCreateNewButton = false;
    private bool isMiniGame = false;
    private bool isNotFirstText = false;

    private List<Button> selectButtons = new();
    private List<BoxView> boxViews = new();
    private List<string> texts = new();

    private GenaralPageFunctions genaralPageFunctions = new();
    private WokringWithUiObject workingWithUiObject = new();
    private WalkingAnimation walkingAnimation = new();
    private ResultMiniGame resultMiniGame = new();

    private CharacterCreationPage characterCreationPage;
    private СharacterСharacteristics сharacterСharacteristics;

    //--------------------------------------------------------------------------------------------------------------------------
    public GamePage(CharacterCreationPage characterCreationPage, СharacterСharacteristics сharacterСharacteristics)
	{
#if DEBUG
        MyLogger.logger.LogInformation("Начало инициализации страницы игрового действия.");
#endif
        InitializeComponent();
        Task InitTask = InitAsync(characterCreationPage, сharacterСharacteristics);
#if DEBUG
        MyLogger.logger.LogInformation("Конец инициализации страницы игрового действия.");
#endif
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private void InitLanguage()
    {
#if DEBUG
        MyLogger.logger.LogInformation("Начало инициализации языка для страницы игры.");
#endif
        switch (SelectLanguage.language)
        {
            case "Ru":
                new Game_Ru(this);
                break;

            case "En":
                new Game_En(this);
                break;

            default:
                new Game_En(this);
                break;
        }
    }
    private async Task InitAsync(CharacterCreationPage characterCreationPage, СharacterСharacteristics сharacterСharacteristics)
    {
        genaralPageFunctions.SetNewLocationStateGameplay("GameMeetingWithGod");
        InitLanguage();
        this.characterCreationPage = characterCreationPage;
        this.сharacterСharacteristics = сharacterСharacteristics;
        await NewStateUi();
        await WalkingAnimation();
        await InitWhiteMainPic();
        await NewStateUi();
        InitSpaceForClick();
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async Task WalkingAnimation()
    {
        await walkingAnimation.Animation(this);
    }
    private async Task InitWhiteMainPic()
    {
        ImageWindow.Source = "whitebackground.png";
        await walkingAnimation.AnimationAppearanceMainPic(ImageWindow);
    }
    private void InitSpaceForClick()
    {
#if DEBUG
        MyLogger.logger.LogInformation("Инициализация области для нажатия (для текста).");
#endif
        TapGestureRecognizer tapGesture = new();
        AddHandlerSpaceForClick(tapGesture);
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private void AddHandlerSpaceForClick(TapGestureRecognizer tapGesture)
    {
        tapGesture.Tapped += async (s, e) =>
        {
            if (!isWait)
            {
#if DEBUG
                MyLogger.logger.LogInformation("Событие: нажатие на игровую область.");
#endif
                await NewStateUi();
                return;
            }
#if DEBUG
            MyLogger.logger.LogInformation("Событие: нажатие на игровую область - занято.");
#endif
        };

        SpaceForClickFirst.GestureRecognizers.Add(tapGesture);
        SpaceForClickSecond.GestureRecognizers.Add(tapGesture);
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async Task NewStateUi()
    {
#if DEBUG
        MyLogger.logger.LogInformation("Получение нужного следующего состояния ui объекта.");
#endif
        StateGameUI state = workingWithUiObject.GetStateUi();

        if (state == StateGameUI.label) await NewStateUI_Label();
        else if (state == StateGameUI.button_two) await NewStateUI_Button(state);
        else if (state == StateGameUI.button_four) await NewStateUI_Button(state);
        else if (state == StateGameUI.img) await NewStateUi_Img();
        else if (state == StateGameUI.audio) await NewStateUi_Audio(state);
        else if (state == StateGameUI.audio_loop) await NewStateUi_Audio(state);
        else if (state == StateGameUI.miniGame) await NewState_StartMiniGame();
        else if (state == StateGameUI.endScene) await NewStateUi_EndScene();
        else return;
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async Task NewStateUI_Label()
    {
#if DEBUG
        MyLogger.logger.LogInformation("Следующий ui объект - Label.");
#endif
        Label newLabel = await CreateNewLabel(workingWithUiObject.GetLabelText());
        await genaralPageFunctions.NewScrollPosition(ScrollAreaLabel, newLabel);
    }
    private async Task NewStateUI_Button(StateGameUI state)
    {
#if DEBUG
        MyLogger.logger.LogInformation("Следующий ui объект - Button.");
#endif
        isWait = true;
        isCreateNewButton = true;

        await CreateNewPanelSelectButtons(state);

        isCreateNewButton = false;

        SelectButtonEnabled();
    }
    private async Task NewStateUi_Img()
    {
#if DEBUG
        MyLogger.logger.LogInformation("Следующий ui объект - Image.");
#endif
        SetNewMainImg(workingWithUiObject.GetMainImg());
        await NewStateUi();
    }
    private async Task NewStateUi_Audio(StateGameUI state)
    {
        await WorkWithSound.StopAudioPlayer();
        await ChoiceAudioIsLoopOrNot(state);
        await ExaminationOnFirstText();
    }
    private async Task NewState_StartMiniGame()
    {
#if DEBUG
        MyLogger.logger.LogInformation("Следующий ui объект - страница миниигры.");
#endif
        if (!CheckProcessBusy.isProcessBusy)
        {
            isMiniGame = true;
            CheckProcessBusy.isProcessBusy = true;
            await Navigation.PushModalAsync(new GuessNumberPlayer(this, сharacterСharacteristics, resultMiniGame));
            CheckProcessBusy.isProcessBusy = false;

#if DEBUG
            MyLogger.logger.LogInformation("Переход на страницу миниигры - успешен.");
#endif
            return;
        }
#if DEBUG
        MyLogger.logger.LogInformation("Кнопка открытия страницы миниигры - занята!");
#endif
    }
    private async Task NewStateUi_EndScene()
    {
#if DEBUG
        MyLogger.logger.LogInformation("Следующий конец сцены.");
#endif
        isWait = true;
        SpaceForClickSecond.Children.Clear();
        await walkingAnimation.AnimationBlackoutMainPic(ImageWindow);
        await walkingAnimation.Animation(this);
        await InitWhiteMainPic();
        isWait = false;
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async Task CreateNewPanelSelectButtons(StateGameUI state)
    {
        BoxView StartLine = genaralPageFunctions.CreateWhiteLine(SpaceForClickSecond, 20, 10);
        SelectingNumberButtons(state);
        await CreateButtonsFromText();
        BoxView EndLine = genaralPageFunctions.CreateWhiteLine(SpaceForClickSecond, 0, 20);
        genaralPageFunctions.AddFromListBoxView(boxViews, StartLine, EndLine);
    }
    private void SelectingNumberButtons(StateGameUI state)
    {
        if (state == StateGameUI.button_four) texts = workingWithUiObject.GetFourButtonsText();
        else texts = workingWithUiObject.GetTwoButtonsText();
    }
    private async Task CreateButtonsFromText()
    {
        foreach (string text in texts)
        {
            Button newButton = await genaralPageFunctions.CreateNewButton(walkingAnimation, text, ScrollAreaLabel);
        }
    }
    private void SelectButtonEnabled()
    {
#if DEBUG
        MyLogger.logger.LogInformation("Перевод кнопок выбора в активное состояние.");
#endif
        foreach (Button button in selectButtons) button.IsEnabled = true;
    }
    private void RemovePanelSelectButtons()
    {
#if DEBUG
        MyLogger.logger.LogInformation("Событие: удаление панели для выбора игрока.");
#endif
        foreach (Button button in selectButtons) SpaceForClickSecond.Remove(button);
        foreach (BoxView boxView in boxViews) SpaceForClickSecond.Remove(boxView);
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async Task ExaminationOnFirstText()
    {
        if (isNotFirstText) await NewStateUi();
        isNotFirstText = true;
    }
    private async Task<Label> CreateNewLabel(string text)
    {
#if DEBUG
        MyLogger.logger.LogInformation("Создание нового текста.");
#endif
        Label label = SelectLabelTitleOrNot(text);
        await walkingAnimation.AnimationLabel(label);
        return label;
    }
    private Label SelectLabelTitleOrNot(string text)
    {
        if (text.StartsWith("(")) return genaralPageFunctions.CreateLabelWithTitle(SpaceForClickSecond, genaralPageFunctions.GetTitleText(text), genaralPageFunctions.GetTitleColor(text), genaralPageFunctions.GetMainText(text));
        else return genaralPageFunctions.CreateLabel(SpaceForClickSecond, text);
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private Button CreateButton(string text)
    {
        Button button = genaralPageFunctions.CreateButton(text);
        button.Clicked += SelectBtn_Clicked;

        genaralPageFunctions.AddToLayoutView(SpaceForClickSecond, button);
        selectButtons.Add(button);

        return button;
    }
    private async void SelectBtn_Clicked(object sender, EventArgs e)
    {
        if (!isCreateNewButton)
        {
#if DEBUG
            MyLogger.logger.LogInformation("Кнопка выбора персонажа - нажата.");
#endif

            Button clickedButton = (Button)sender;
            string text = $"({сharacterСharacteristics.characterName},{genaralPageFunctions.ChoiceMainCharacterTitleColor(сharacterСharacteristics)})" + clickedButton.Text;

            RemovePanelSelectButtons();

            Label newLabel = await CreateNewLabel(text);
            await genaralPageFunctions.NewScrollPosition(ScrollAreaLabel, newLabel);

            await Task.Delay(300);

            await NewStateUi();
            isWait = false;

            return;
        }
#if DEBUG
        MyLogger.logger.LogInformation("Кнопка выбора персонажа - занята!");
#endif
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private void SetNewMainImg(string imgName)
    {
#if DEBUG
        MyLogger.logger.LogInformation($"Установка новой картинки - {imgName}.");
#endif
        ImageWindow.Source = imgName;
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async Task ChoiceAudioIsLoopOrNot(StateGameUI state)
    {
        if (state == StateGameUI.audio) await WorkWithSound.InitNewAudioPlayer(workingWithUiObject.GetAudio(), false);
        else await WorkWithSound.InitNewAudioPlayer(workingWithUiObject.GetAudio(), true);
    }
    private void AudioBtn_Clicked(object sender, EventArgs e)
    {
        if (audioBtn.Text == "🔊") genaralPageFunctions.AudioOff(audioBtn);
        else genaralPageFunctions.AudioOn(audioBtn);
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async void MenuBtn_Clicked(object sender, EventArgs e)
    {
        await CloseGamePageAndCharacterCreationPage(false);
    }
    public async Task CloseGamePageAndCharacterCreationPage(bool isCallMiniGame)
    {
        if (!CheckProcessBusy.isProcessBusy)
        {
#if DEBUG
            MyLogger.logger.LogInformation("Кнопка открытия страницы выбора одиночной игры - нажата!");
#endif
            CheckProcessBusy.isProcessBusy = true;
            await SettingMenuAudio("Menu.mp3", true);
            await Navigation.PopModalAsync(false);
            await CallFromMiniGameClose(isCallMiniGame);
            CheckProcessBusy.isProcessBusy = false;
            return;
        }
#if DEBUG
        MyLogger.logger.LogInformation("Кнопка открытия страницы выбора одиночной игры - занята!");
#endif
    }
    private async Task SettingMenuAudio(string audioName, bool isLoop)
    {
        await WorkWithSound.StopAudioPlayer();
        await WorkWithSound.InitNewAudioPlayer(audioName, isLoop);
    }
    //--------------------------------------------------------------------------------------------------------------------------
    protected async override void OnDisappearing()
    {
        if (!isMiniGame) await CloseGamePage();
        else await IsMinigamePage();
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async Task CallFromMiniGameClose(bool isCallMiniGame)
    {
        if (isCallMiniGame) await Navigation.PopModalAsync(false);
        else return;
    }
    private async Task CloseGamePage()
    {
#if DEBUG
        MyLogger.logger.LogInformation("Закрытие страницы игры.");
#endif
        base.OnDisappearing();
        await characterCreationPage.BackGamePage();
#if DEBUG
        MyLogger.logger.LogInformation("Переход на страницу выбора одиночной игры - успешен.");
#endif
    }
    private async Task IsMinigamePage()
    {
        isMiniGame = false;
        await NewStateUi();
    }
    //--------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------