//Класс для реализации основной игры
//------------------------------------------------------------------------------------------------------------------------------

namespace QuantumJourneys.Pages.Game;

//------------------------------------------------------------------------------------------------------------------------------
public partial class GamePage : ContentPage
{
    private bool isBusy = false;
    private bool isWaitSelectButton = false;
    private bool isCreateNewButton = false;

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
        await CreateNewLabel(meetingWithGodTextTransfer.GiveFirstText());
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
            if (!isWaitSelectButton) await NewStateUi();
        };

        SpaceForClickFirst.GestureRecognizers.Add(tapGesture);
        SpaceForClickSecond.GestureRecognizers.Add(tapGesture);
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async Task NewStateUi()
    {
        StateGameUI state = meetingWithGodTextTransfer.GiveStateUi();

        if (state == StateGameUI.label) await NewStateUI_Label();
        else if (state == StateGameUI.button) await NewStateUI_Button();
        else return;
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async Task NewStateUI_Label()
    {
        Label newLabel = await CreateNewLabel(meetingWithGodTextTransfer.GiveLabelText());
        await NewScrollPosition(newLabel);
    }
    private async Task NewStateUI_Button()
    {
        isWaitSelectButton = true;
        isCreateNewButton = true;

        BoxView StartLine = CreateWhiteLine(20, 10);

        List<string> texts = meetingWithGodTextTransfer.GiveButtonsText();

        foreach (string text in texts)
        {
            Button newButton = await CreateNewButton(text);
            await NewScrollPosition(newButton);
        }

        BoxView EndLine = CreateWhiteLine(0, 20);

        AddFromListBoxView(StartLine, EndLine);
        isCreateNewButton = false;

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
            Button clickedButton = (Button)sender;
            string text = clickedButton.Text;

            foreach (Button button in selectButtons) SpaceForClickSecond.Remove(button);
            foreach (BoxView boxView in boxViews) SpaceForClickSecond.Remove(boxView);

            Label newLabel = await CreateNewLabel(text);
            await NewScrollPosition(newLabel);

            await Task.Delay(300);

            await NewStateUi();
            isWaitSelectButton = false;
        }
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
        if (audioBtn.Text == "🔊")
        {
            audioBtn.Text = "🔇";
            WorkingAudioPlayer.audioPlayer.Volume = 0;
#if DEBUG
            MyLogger.logger.LogInformation("Звук отключен.");
#endif
        }
        else
        {
            audioBtn.Text = "🔊";
            WorkingAudioPlayer.audioPlayer.Volume = WorkingAudioPlayer.valume;
#if DEBUG
            MyLogger.logger.LogInformation("Звук включен.");
#endif
        }
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
#if DEBUG
        MyLogger.logger.LogInformation("Закрытие страницы создания персонажа.");
#endif
        base.OnDisappearing();
        await characterCreationPage.BackGamePage();
#if DEBUG
        MyLogger.logger.LogInformation("Переход на страницу выбора одиночной игры - успешен.");
#endif
    }
    //--------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------