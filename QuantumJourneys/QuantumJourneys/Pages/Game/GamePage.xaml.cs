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

    private WalkingAnimation walkingAnimation;
    private CharacterCreationPage characterCreationPage;
    private MeetingWithGodTextTransfer meetingWithGodTextTransfer;

    //--------------------------------------------------------------------------------------------------------------------------
    public GamePage(CharacterCreationPage characterCreationPage)
	{
#if DEBUG
        MyLogger.logger.LogInformation("Начало инициализации страницы игрового действия.");
#endif
        InitializeComponent();
        InitLanguage();
        Task InitTask = InitAsync(characterCreationPage);
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
    private async Task InitAsync(CharacterCreationPage characterCreationPage)
    {
        meetingWithGodTextTransfer = new();
        this.characterCreationPage = characterCreationPage;
        await NewStateUi();
        await WalkingAnimation();
        await InitWhiteMainPic();
        await NewStateUi();
        InitSpaceForClick();
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async Task WalkingAnimation()
    {
        WalkingAnimation walkingAnimation = new();
        this.walkingAnimation = walkingAnimation;
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
        StateGameUI state = meetingWithGodTextTransfer.GetStateUi();

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
        Label newLabel = await CreateNewLabel(meetingWithGodTextTransfer.GetLabelText());
        await NewScrollPosition(newLabel);
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
        SetNewMainImg(meetingWithGodTextTransfer.GetMainImg());
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
            await Navigation.PushModalAsync(new MiniGame_OpenDoor("MeetingWithGodSound.mp3"));
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
        BoxView StartLine = CreateWhiteLine(20, 10);
        SelectingNumberButtons(state);
        await CreateButtonsFromText();
        BoxView EndLine = CreateWhiteLine(0, 20);
        AddFromListBoxView(StartLine, EndLine);
    }
    private void SelectingNumberButtons(StateGameUI state)
    {
        if (state == StateGameUI.button_four) texts = meetingWithGodTextTransfer.GetFourButtonsText();
        else texts = meetingWithGodTextTransfer.GetTwoButtonsText();
    }
    private async Task CreateButtonsFromText()
    {
        foreach (string text in texts)
        {
            Button newButton = await CreateNewButton(text);
            await NewScrollPosition(newButton);
        }
    }
    private void SelectButtonEnabled()
    {
#if DEBUG
        MyLogger.logger.LogInformation("Перевод кнопок выбора в активное состояние.");
#endif
        foreach (Button button in selectButtons) button.IsEnabled = true;
    }
    private void RemovePandelSelectButtons()
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
        Label label = CreateLabel(text);
        await walkingAnimation.AnimationLabel(label);

        return label;
    }
    private Label CreateLabel(string text)
    {
        Label label = new()
        {
            Opacity = 0,
            Text = text,
            FontSize = 20,
            HorizontalTextAlignment = TextAlignment.Start,
            LineBreakMode = LineBreakMode.WordWrap,
            VerticalOptions = LayoutOptions.Start,
            Margin = new Thickness(0,0,0,20)
        };

        SpaceForClickSecond.Add(label);

        return label;
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async Task<Button> CreateNewButton(string text)
    {
#if DEBUG
        MyLogger.logger.LogInformation("Создание новой кнопки.");
#endif
        Button button = CreateButton(text);
        await walkingAnimation.AnimationButton(button);

        return button;
    }
    private Button CreateButton(string text)
    {
        Button button = new()
        {
            Opacity = 0,
            Text = text,
            FontSize = 20,

            IsEnabled = false,

            VerticalOptions = LayoutOptions.Start,
            Margin = new Thickness(0, 0, 0, 10)
        };
        button.Clicked += SelectBtn_Clicked;

        SpaceForClickSecond.Add(button);
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
            string text = clickedButton.Text;

            RemovePandelSelectButtons();

            Label newLabel = await CreateNewLabel(text);
            await NewScrollPosition(newLabel);

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
    private BoxView CreateWhiteLine(int topMargin, int backMargin)
    {
#if DEBUG
        MyLogger.logger.LogInformation("Создание белой линии.");
#endif
        BoxView boxView = new BoxView
        {
            BackgroundColor = Colors.White,
            VerticalOptions = LayoutOptions.Start,
            HeightRequest = 5,
            Margin = new Thickness(0, topMargin, 0, backMargin)
        };

        SpaceForClickSecond.Add(boxView);

        return boxView;
    }
    private void AddFromListBoxView(BoxView StartLine, BoxView EndLine)
    {
        boxViews.Add(StartLine);
        boxViews.Add(EndLine);
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
    private async Task NewScrollPosition(View view)
    {
#if DEBUG
        MyLogger.logger.LogInformation("Изменение позиции скролла.");
#endif
        await ScrollAreaLabel.ScrollToAsync(view, ScrollToPosition.End, true);
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async Task ChoiceAudioIsLoopOrNot(StateGameUI state)
    {
        if (state == StateGameUI.audio) await WorkWithSound.InitNewAudioPlayer(meetingWithGodTextTransfer.GetAudio(), false);
        else await WorkWithSound.InitNewAudioPlayer(meetingWithGodTextTransfer.GetAudio(), true);
    }
    private void AudioBtn_Clicked(object sender, EventArgs e)
    {
        if (audioBtn.Text == "🔊") AudioOff();
        else AudioOn();
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private void AudioOff()
    {
        audioBtn.Text = "🔇";
        WorkingAudioPlayer.audioPlayer.Volume = 0;
#if DEBUG
        MyLogger.logger.LogInformation("Звук отключен.");
#endif
    }
    private void AudioOn()
    {
        audioBtn.Text = "🔊";
        WorkingAudioPlayer.audioPlayer.Volume = WorkingAudioPlayer.valume;
#if DEBUG
        MyLogger.logger.LogInformation("Звук включен.");
#endif
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async void MenuBtn_Clicked(object sender, EventArgs e)
    {
        if (!CheckProcessBusy.isProcessBusy)
        {
#if DEBUG
            MyLogger.logger.LogInformation("Кнопка открытия страницы выбора одиночной игры - нажата!");
#endif
            CheckProcessBusy.isProcessBusy = true;
            await SettingMenuAudio();
            await Navigation.PopModalAsync();
            CheckProcessBusy.isProcessBusy = false;
            return;
        }
#if DEBUG
        MyLogger.logger.LogInformation("Кнопка открытия страницы выбора одиночной игры - занята!");
#endif
    }
    private async Task SettingMenuAudio()
    {
        await WorkWithSound.StopAudioPlayer();
        await WorkWithSound.InitNewAudioPlayer("Menu.mp3", true);
    }
    //--------------------------------------------------------------------------------------------------------------------------
    protected async override void OnDisappearing()
    {
        if (!isMiniGame) await CloseGamePage();
        else await IsMinigamePage();
    }
    //--------------------------------------------------------------------------------------------------------------------------
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