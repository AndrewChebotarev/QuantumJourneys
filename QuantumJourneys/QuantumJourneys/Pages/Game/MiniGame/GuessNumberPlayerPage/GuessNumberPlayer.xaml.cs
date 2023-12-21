//Класс для работы с миниигрой - угадай число (игрок)
//------------------------------------------------------------------------------------------------------------------------------

using System.Runtime.CompilerServices;

namespace QuantumJourneys.Pages.MiniGame.GuessNumberPlayerPage;

//------------------------------------------------------------------------------------------------------------------------------
public partial class GuessNumberPlayer : ContentPage
{
    //--------------------------------------------------------------------------------------------------------------------------

    private bool isWait = false;
    private bool isCreateNewButton = false;
    private bool isNotDefaultEndGame = true;


    private int numberAttempts = 7;
    private int intendedNumber;
    private int playerNumber;
    private Random rnd_Number = new();

    private List<BoxView> boxViews = new();
    private Dictionary<Button, Entry> EntryButtonDictionary = new();

    private GamePage gamePage;
    private WokringWithUiObject workingWithUiObject;
    private WalkingAnimation walkingAnimation;
    private СharacterСharacteristics сharacterСharacteristics;
    private ResultMiniGame resultMiniGame;

    //--------------------------------------------------------------------------------------------------------------------------
    public GuessNumberPlayer(GamePage gamePage, СharacterСharacteristics сharacterСharacteristics, ResultMiniGame resultMiniGame)
    {
#if DEBUG
        MyLogger.logger.LogInformation("Начало инициализации мини игры - угудай число для игрока.");
#endif
        InitializeComponent();
        InitAsync(gamePage, сharacterСharacteristics, resultMiniGame);
#if DEBUG
        MyLogger.logger.LogInformation("Конец инициализации мини игры - угадай число для бога.");
#endif
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async void InitAsync(GamePage gamePage, СharacterСharacteristics сharacterСharacteristics, ResultMiniGame resultMiniGame)
    {
        SetNewLocationStateGameplay("MiniGameGuessNumberPlayer");
        InitLanguage();
        workingWithUiObject = new();
        walkingAnimation = new();
        this.сharacterСharacteristics = сharacterСharacteristics;
        this.resultMiniGame = resultMiniGame;
        this.gamePage = gamePage;
        GetIntendedNumber();
        await NewStateUi();
        InitSpaceForClick();
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private void SetNewLocationStateGameplay(string newLocationState)
    {
        LocationStateGameplay.locationStateGameplay = newLocationState;
    }
    private void InitLanguage()
    {
#if DEBUG
        MyLogger.logger.LogInformation("Начало инициализации языка для страницы миниигры.");
#endif
        switch (SelectLanguage.language)
        {
            case "Ru":
                new GuessNumberPlayer_Ru(this);
                break;
            case "En":
                new GuessNumberPlayer_En(this);
                break;
            default:
                new GuessNumberPlayer_En(this);
                break;
        }
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
    private void GetIntendedNumber()
    {
        intendedNumber = rnd_Number.Next(0, 100);
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async Task NewStateUi()
    {
#if DEBUG
        MyLogger.logger.LogInformation("Получение нужного следующего состояния ui объекта.");
#endif
        StateGameUI state = workingWithUiObject.GetStateUi();

        if (state == StateGameUI.label) await NewStateUI_Label();
        else if (state == StateGameUI.nameMiniGame) await NewStateUI_NameMiniGame();
        else if (state == StateGameUI.entry_button) await NewStateUI_EntryButton();
        else if (state == StateGameUI.endMiniGame) await NewStateUI_EndMiniGame();
        else return;
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async Task NewStateUI_Label()
    {
#if DEBUG
        MyLogger.logger.LogInformation("Следующий ui объект - Label.");
#endif
        Label newLabel = await CreateNewLabel(workingWithUiObject.GetLabelText());
        await NewScrollPosition(newLabel);
    }
    private async Task NewStateUI_NameMiniGame()
    {
#if DEBUG
        MyLogger.logger.LogInformation("Следующий ui объект - Label (название игры).");
#endif
        await CreateNameMiniGame();
    }
    private async Task NewStateUI_EntryButton()
    {
        isWait = true;
        isCreateNewButton = true;

        await CreateNewPanelEntryWithButton();

        isCreateNewButton = false;
    }
    private async Task NewStateUI_EndMiniGame()
    {
        await WorkWithSound.StopAudioPlayer();
        await WorkWithSound.InitNewAudioPlayer("MeetingWithGodSound.mp3", true);
        isNotDefaultEndGame = false;
        await Navigation.PopModalAsync();
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async Task CreateNameMiniGame()
    {
        Label newNameMiniGame = CreateLabelNameMiniGame(workingWithUiObject.GetNameNameMiniGame());
        await walkingAnimation.AnimationLabel(newNameMiniGame);
        await NewScrollPosition(newNameMiniGame);
        await NewStateUi();
    }
    private Label CreateLabelNameMiniGame(string text)
    {
        Label label = new()
        {
            Opacity = 0,
            Text = text,
            FontSize = 24,
            FontAttributes = FontAttributes.Bold,
            TextDecorations = TextDecorations.Underline,
            HorizontalTextAlignment = TextAlignment.Center,
            LineBreakMode = LineBreakMode.WordWrap,
            VerticalOptions = LayoutOptions.Start,
            Margin = new Thickness(0, 0, 0, 20)
        };

        SpaceForClickSecond.Add(label);

        return label;
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async Task<Label> CreateNewLabel(string text)
    {
#if DEBUG
        MyLogger.logger.LogInformation("Создание нового текста.");
#endif
        Label label = CreateLabelWithTitle(GetTitleText(text), GetTitleColor(text), GetMainText(text));
        await walkingAnimation.AnimationLabel(label);
        return label;
    }
    private string GetTitleText(string text) => text.Substring(1, text.IndexOf(",") - 1);
    private string GetTitleColor(string text) => text.Substring(text.IndexOf(",") + 1, (text.IndexOf(")") - text.IndexOf(",")) - 1);
    private string GetMainText(string text) => text.Remove(0, text.IndexOf(")") + 1);
    private Label CreateLabelWithTitle(string title, string color, string text)
    {
        Label label = new()
        {
            Opacity = 0,
            FontSize = 20,
            HorizontalTextAlignment = TextAlignment.Center,
            LineBreakMode = LineBreakMode.WordWrap,
            VerticalOptions = LayoutOptions.Start,
            Margin = new Thickness(0, 0, 0, 20)
        };

        FormattedString formattedString = new();
        SetTitleForLabel(formattedString, title, color);
        SetTextForLabel(formattedString, text);
        label.FormattedText = formattedString;
        SpaceForClickSecond.Add(label);

        return label;
    }
    private void SetTitleForLabel(FormattedString formattedString, string title, string color)
    {
        formattedString.Spans.Add(new Span
        {
            Text = title + ": ",
            TextColor = ChoiceColorForTitle(color),
            FontAttributes = FontAttributes.Bold
        });
    }
    private void SetTextForLabel(FormattedString formattedString, string text)
    {
        formattedString.Spans.Add(new Span
        {
            Text = text,
        });
    }
    private Color ChoiceColorForTitle(string color)
    {
        if (color == "White") return Colors.White;
        else if (color == "Blue") return Colors.Blue;
        else if (color == "Brown") return Colors.Brown;
        else if (color == "Green") return Colors.Green;
        else return Colors.White;
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async Task CreateNewPanelEntryWithButton()
    {
        EntryButtonDictionary.Clear();
        BoxView StartLine = CreateWhiteLine(20, 10);
        List<string> EntryButtonTexts = workingWithUiObject.GetEntryButtonText();
        Entry entry = await CreateNewEntry(EntryButtonTexts[0]);
        Button button = await CreateNewButton(EntryButtonTexts[1]);
        BoxView EndLine = CreateWhiteLine(0, 20);
        EntryEnabled(entry);
        EntryButtonDictionary.Add(button, entry);
        AddFromListBoxView(StartLine, EndLine);
    }
    private void EntryEnabled(Entry entry)
    {
        entry.IsEnabled = true;
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async Task<Entry> CreateNewEntry(string text)
    {
#if DEBUG
        MyLogger.logger.LogInformation("Создание нового текстового поля.");
#endif
        Entry entry = CreateEntry(text);
        await walkingAnimation.AnimationEntry(entry);
        await NewScrollPosition(entry);

        return entry;
    }
    private Entry CreateEntry(string text)
    {
        Entry entry = new Entry()
        {
            Opacity = 0,
            Placeholder = text,
            FontSize = 20,

            IsEnabled = false,

            Keyboard = Keyboard.Numeric,

            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
            HorizontalTextAlignment = TextAlignment.Center,
            Margin = new Thickness(0, 0, 0, 10)
        };
        entry.Completed += (sender, e) => CloseKeyboard_Clicked((Entry)sender);

        SpaceForClickSecond.Add(entry);

        return entry;
    }
    private void CloseKeyboard_Clicked(Entry entry)
    {
        entry.IsEnabled = false;
        entry.IsEnabled = true;

        try
        {
            playerNumber = int.Parse(entry.Text);
            Button button = EntryButtonDictionary.Keys.FirstOrDefault();
            button.IsEnabled = true;
        }
        catch
        {
            DisplayAlert("Некорректное значение!", "Введите целое число.", "Ок");
        }
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async Task<Button> CreateNewButton(string text)
    {
#if DEBUG
        MyLogger.logger.LogInformation("Создание новой кнопки.");
#endif
        Button button = CreateButton(text);
        await walkingAnimation.AnimationButton(button);
        await NewScrollPosition(button);

        return button;
    }
    private Button CreateButton(string text)
    {
        Button button = new()
        {
            Opacity = 0,
            Text = text,
            FontSize = 20,
            LineBreakMode = LineBreakMode.WordWrap,

            IsEnabled = false,

            VerticalOptions = LayoutOptions.Start,
            Margin = new Thickness(0, 0, 0, 10)
        };
        button.Clicked += SelectBtn_Clicked;

        SpaceForClickSecond.Add(button);

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
            string text = $"({сharacterСharacteristics.characterName},{ChoiceMainCharacterTitleColor()})" + playerNumber;

            RemovePanelEntryWithButton((Button)sender);

            Label newLabel = await CreateNewLabel(text);
            await NewScrollPosition(newLabel);

            await Task.Delay(300);

            bool isAutoNewStateUi = await CheckPlayerIsGuessedNubmer();
            numberAttempts--;

            if (isAutoNewStateUi) await NewStateUi();
            isWait = false;

            return;
        }
#if DEBUG
        MyLogger.logger.LogInformation("Кнопка выбора персонажа - занята!");
#endif
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async Task<bool> CheckPlayerIsGuessedNubmer()
    {
        if (intendedNumber == playerNumber) return await PlayerGuessedNumber();
        else if (numberAttempts == 0) return await CheckRanOutAttempts();
        else return await PlayerNotGuessedNumber();
    }
    private async Task<bool> PlayerGuessedNumber()
    {
        workingWithUiObject.CounterStepsForward(2);
        resultMiniGame.GuessNumberPlayer = true;
        await NewStateUi();
        workingWithUiObject.CounterStepsForward(1);
        return false;
    }
    private async Task<bool> PlayerNotGuessedNumber()
    {
        if (intendedNumber > playerNumber)
        {
            await NewStateUi();
            workingWithUiObject.CounterStepsBack(3);
            return true;
        }
        else
        {
            workingWithUiObject.CounterStepsForward(1);
            await NewStateUi();
            workingWithUiObject.CounterStepsBack(4);
            return true;
        }
    }
    private async Task<bool> CheckRanOutAttempts()
    {
        workingWithUiObject.CounterStepsForward(3);
        resultMiniGame.GuessNumberPlayer = false;
        await NewStateUi();
        return false;
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
    private void RemovePanelEntryWithButton(Button button)
    {
        SpaceForClickSecond.Remove(boxViews[0]);
        SpaceForClickSecond.Remove(EntryButtonDictionary[button]);
        SpaceForClickSecond.Remove(button);
        SpaceForClickSecond.Remove(boxViews[1]);
        boxViews.Clear();
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private string ChoiceMainCharacterTitleColor()
    {
        if (сharacterСharacteristics.eyeColor == EyeColorEnum.Blue) return "Blue";
        else if (сharacterСharacteristics.eyeColor == EyeColorEnum.Brown) return "Brown";
        else if (сharacterСharacteristics.eyeColor == EyeColorEnum.Green) return "Green";
        else return "Blue";
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
        if (!isWait)
        {
#if DEBUG
            MyLogger.logger.LogInformation("Кнопка открытия страницы выбора одиночной игры - нажата!");
#endif
            isWait = true;
            await gamePage.CloseGamePageAndCharacterCreationPage(true);
            isWait = false;
            return;
        }
#if DEBUG
        MyLogger.logger.LogInformation("Кнопка открытия страницы выбора одиночной игры - занята!");
#endif
    }
    //--------------------------------------------------------------------------------------------------------------------------
    protected async override void OnDisappearing()
    {
        if (isNotDefaultEndGame) await gamePage.CloseGamePageAndCharacterCreationPage(true);
    }
    protected override bool OnBackButtonPressed()
    {
        Task task = gamePage.CloseGamePageAndCharacterCreationPage(true);
        return true;
    }
    //--------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------
