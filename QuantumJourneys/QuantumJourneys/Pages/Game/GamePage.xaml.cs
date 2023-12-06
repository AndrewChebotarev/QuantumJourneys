//Класс для реализации основной игры
//------------------------------------------------------------------------------------------------------------------------------

namespace QuantumJourneys.Pages.Game;

//------------------------------------------------------------------------------------------------------------------------------
public partial class GamePage : ContentPage
{
    private bool isBusy = false;
    private bool isWaitSelectButton = false;
    private bool isCreateNewButton = false;
    public bool isNotMiniGame = true;

    private List<Button> selectButtons = new();
    private List<BoxView> boxViews = new();

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
        await WalkingAnimation();
        await InitWhiteMainPic();
        await CreateNewLabel(meetingWithGodTextTransfer.SetFirstText());
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
        await walkingAnimation.AnimationMainPic(ImageWindow);
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
            if (!isWaitSelectButton)
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
        StateGameUI state = meetingWithGodTextTransfer.GetStateUi();

        if (state == StateGameUI.label) await NewStateUI_Label();
        else if (state == StateGameUI.button_two) await NewStateUI_Button(StateGameUI.button_two);
        else if (state == StateGameUI.button_four) await NewStateUI_Button(StateGameUI.button_four);
        else if (state == StateGameUI.img) await NewStateUi_Img();
        else if (state == StateGameUI.miniGame) await NewState_StartMiniGame();
        else if (state == StateGameUI.endScene) await NewStateUi_EndScene();
        else return;
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async Task NewStateUI_Label()
    {
        Label newLabel = await CreateNewLabel(meetingWithGodTextTransfer.GetLabelText());
        await NewScrollPosition(newLabel);
    }
    private async Task NewStateUI_Button(StateGameUI state)
    {
        isWaitSelectButton = true;
        isCreateNewButton = true;

        await CreateNewPanelSelectButtons(state);

        isCreateNewButton = false;

        SelectButtonEnabled();
    }
    private async Task NewStateUi_Img()
    {
        SetNewMainImg(meetingWithGodTextTransfer.GetMainImg());
        await NewStateUi();
    }
    private async Task NewState_StartMiniGame()
    {
        if (!isBusy)
        {
            isNotMiniGame = false;
            isBusy = true;
            await Navigation.PushModalAsync(new MiniGame_OpenDoor());
            isBusy = false;

#if DEBUG
            MyLogger.logger.LogInformation("Переход на страницу выбора одиночной игры - успешен.");
#endif
            return;
        }
#if DEBUG
        MyLogger.logger.LogInformation("Кнопка открытия страницы выбора одиночной игры - занята!");
#endif
    }

    //--------------------------------------------------------------------------------------------------------------------------
    private async Task CreateNewPanelSelectButtons(StateGameUI state)
    {
        BoxView StartLine = CreateWhiteLine(20, 10);

        List<string> texts = new();

        if (state == StateGameUI.button_four) texts = meetingWithGodTextTransfer.GetFourButtonsText();
        else texts = meetingWithGodTextTransfer.GetTwoButtonsText();

        foreach (string text in texts)
        {
            Button newButton = await CreateNewButton(text);
            await NewScrollPosition(newButton);
        }

        BoxView EndLine = CreateWhiteLine(0, 20);

        AddFromListBoxView(StartLine, EndLine);
    }
    private void SelectButtonEnabled()
    {
        foreach (Button button in selectButtons) button.IsEnabled = true;
    }
    //--------------------------------------------------------------------------------------------------------------------------
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
            isWaitSelectButton = false;

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
    private void RemovePandelSelectButtons()
    {
#if DEBUG
        MyLogger.logger.LogInformation("Событие: удаление панели для выбора игрока.");
#endif
        foreach (Button button in selectButtons) SpaceForClickSecond.Remove(button);
        foreach (BoxView boxView in boxViews) SpaceForClickSecond.Remove(boxView);
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private void SetNewMainImg(string imgName)
    {
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
        if (!isBusy)
        {
            isBusy = true;
            await Navigation.PopModalAsync();
            isBusy = false;
            return;
        }
#if DEBUG
        MyLogger.logger.LogInformation("Кнопка открытия страницы выбора одиночной игры - занята!");
#endif
    }
    //--------------------------------------------------------------------------------------------------------------------------
    protected async override void OnDisappearing()
    {
        if (isNotMiniGame)
        {
#if DEBUG
            MyLogger.logger.LogInformation("Закрытие страницы создания персонажа.");
#endif
            base.OnDisappearing();
            await characterCreationPage.BackGamePage();
#if DEBUG
            MyLogger.logger.LogInformation("Переход на страницу выбора одиночной игры - успешен.");
#endif
        }
        else
        {
            isNotMiniGame = true;
            await NewStateUi();
        }
    }
    //--------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------