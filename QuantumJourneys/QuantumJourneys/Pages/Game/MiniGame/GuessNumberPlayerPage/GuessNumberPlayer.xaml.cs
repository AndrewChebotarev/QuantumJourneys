//Класс для работы с миниигрой - угадай число (игрок)
//------------------------------------------------------------------------------------------------------------------------------

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

    private GenaralPageFunctions genaralPageFunctions = new();
    private WokringWithUiObject workingWithUiObject = new();
    private WalkingAnimation walkingAnimation = new();

    private GamePage gamePage;
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
        genaralPageFunctions.SetNewLocationStateGameplay("MiniGameGuessNumberPlayer");
        InitLanguage();
        this.сharacterСharacteristics = сharacterСharacteristics;
        this.resultMiniGame = resultMiniGame;
        this.gamePage = gamePage;
        genaralPageFunctions.GetIntendedNumber(rnd_Number, 1, 100);
        await NewStateUi();
        InitSpaceForClick();
    }
    //--------------------------------------------------------------------------------------------------------------------------
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
        Label newLabel = await genaralPageFunctions.CreateNewLabel(SpaceForClickSecond, workingWithUiObject.GetLabelText(), walkingAnimation);
        await genaralPageFunctions.NewScrollPosition(ScrollAreaLabel, newLabel);
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
        await genaralPageFunctions.SettingMenuAudio("MeetingWithGodSound.mp3", true);
        isNotDefaultEndGame = false;
        await Navigation.PopModalAsync();
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async Task CreateNameMiniGame()
    {
        Label newNameMiniGame = await genaralPageFunctions.CreateLabelNameMiniGame(ScrollAreaLabel, workingWithUiObject.GetNameNameMiniGame());
        await walkingAnimation.AnimationLabel(newNameMiniGame);
        await genaralPageFunctions.NewScrollPosition(ScrollAreaLabel, newNameMiniGame);
        await NewStateUi();
    }

    //--------------------------------------------------------------------------------------------------------------------------
    private async Task CreateNewPanelEntryWithButton()
    {
        EntryButtonDictionary.Clear();
        BoxView StartLine = genaralPageFunctions.CreateWhiteLine(SpaceForClickSecond, 20, 10);
        List<string> EntryButtonTexts = workingWithUiObject.GetEntryButtonText();
        Entry entry = await CreateNewEntry(EntryButtonTexts[0]);
        Button button = await CreateNewButton(EntryButtonTexts[1]);
        BoxView EndLine = genaralPageFunctions.CreateWhiteLine(SpaceForClickSecond, 0, 20);
        genaralPageFunctions.EntryEnabled(entry);
        EntryButtonDictionary.Add(button, entry);
        genaralPageFunctions.AddFromListBoxView(boxViews, StartLine, EndLine);
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async Task<Entry> CreateNewEntry(string text)
    {
#if DEBUG
        MyLogger.logger.LogInformation("Создание нового текстового поля.");
#endif
        Entry entry = CreateEntry(text);
        await walkingAnimation.AnimationEntry(entry);
        await genaralPageFunctions.NewScrollPosition(ScrollAreaLabel, entry);

        return entry;
    }
    private Entry CreateEntry(string text)
    {
        Entry entry = genaralPageFunctions.CreateEntry(text);
        entry.Completed += (sender, e) => CloseKeyboard_Clicked((Entry)sender);

        genaralPageFunctions.AddToLayoutView(SpaceForClickSecond, entry);

        return entry;
    }
    private void CloseKeyboard_Clicked(Entry entry)
    {
        genaralPageFunctions.CloseKeyboard_Clicked(entry);

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

    public async Task<Button> CreateNewButton(string text)
    {
#if DEBUG
        MyLogger.logger.LogInformation("Создание новой кнопки.");
#endif
        Button button = CreateButton(text);
        await walkingAnimation.AnimationButton(button);
        await genaralPageFunctions.NewScrollPosition(ScrollAreaLabel, button);

        return button;
    }
    private Button CreateButton(string text)
    {
        Button button = genaralPageFunctions.CreateButton(text);
        button.Clicked += SelectBtn_Clicked;

        genaralPageFunctions.AddToLayoutView(SpaceForClickSecond, button);

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
            string text = $"({сharacterСharacteristics.characterName},{genaralPageFunctions.ChoiceMainCharacterTitleColor(сharacterСharacteristics)})" + playerNumber;

            RemovePanelEntryWithButton((Button)sender);

            Label newLabel = await genaralPageFunctions.CreateNewLabel(SpaceForClickSecond, text, walkingAnimation);
            await genaralPageFunctions.NewScrollPosition(ScrollAreaLabel, newLabel);

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
    private void RemovePanelEntryWithButton(Button button)
    {
        SpaceForClickSecond.Remove(boxViews[0]);
        SpaceForClickSecond.Remove(EntryButtonDictionary[button]);
        SpaceForClickSecond.Remove(button);
        SpaceForClickSecond.Remove(boxViews[1]);
        boxViews.Clear();
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private void AudioBtn_Clicked(object sender, EventArgs e)
    {
        if (audioBtn.Text == "🔊") genaralPageFunctions.AudioOff(audioBtn);
        else genaralPageFunctions.AudioOn(audioBtn);
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
