//Класс для создания персонажа игрока
//--------------------------------------------------------------------------------------------------------------------------------------

namespace QuantumJourneys.Pages.СharacterCreation;


//--------------------------------------------------------------------------------------------------------------------------------------
public partial class CharacterCreationPage : ContentPage
{
    //----------------------------------------------------------------------------------------------------------------------------------

    private string characteristicsName;
    private int numberStatsChange;

    private CharacterCreation_En characterCreation_En;
    private CharacterCreation_Ru characterCreation_Ru;

    private Button loadGameBtn;

    private СharacterСharacteristics сharacterСharacteristics;
    private SelectedGenderСharacter selectedGenderCharacter;
    private SelectedEyeColorCharacter selectedEyeColorCharacter;
    private SelectedHairColorCharacter selectedHairColorCharacter;
    private SelectedMentalityCharacter selectedMentalityCharacter;
    private SelectedProfessionCharacter selectedProfessionCharacter;
    private SelectedNatureCharacter selectedNatureCharacter;
    private SelectedStatCharacter selectedStatCharacter;

    //----------------------------------------------------------------------------------------------------------------------------------
    public CharacterCreationPage(Button loadGameBtn)
    {
#if DEBUG
        MyLogger.logger.LogInformation("Начало инициализации страницы создания персонажа.");
#endif
        InitializeComponent();
        InitLanguage();
        InitDefaultCharacteristics(loadGameBtn);
#if DEBUG
        MyLogger.logger.LogInformation("Конец инициализации страницы создания персонажа.");
#endif
    }
    private void InitLanguage()
    {
#if DEBUG
        MyLogger.logger.LogInformation("Начало инициализации языка для страницы создания персонажа.");
#endif
        switch (SelectLanguage.language)
        {
            case "Ru":
                characterCreation_Ru = new(this);
                break;

            case "En":
                characterCreation_En = new(this);
                break;

            default:
                characterCreation_En = new(this);
                break;
        }
    }
    private void InitDefaultCharacteristics(Button loadGameBtn)
    {
        сharacterСharacteristics = new()
        {
            img = ImgCharacterEnum.FemaleBrownGinger,
            gender = GenderEnum.Female,
            eyeColor = EyeColorEnum.Brown,
            hairColor = HairColorEnum.Ginger,
            mentality = MentalityEnum.Technical,
            profession = ProfessionEnum.Teacher,
            character = СharacterEnum.Choleric,
            strength = 1,
            agiluty = 1,
            intelligence = 1,
            fortune = 1,
            characterName = ""
        };

        this.loadGameBtn = loadGameBtn;

        ImageMainCharacter.Source = "femalebrownginger.png";

        selectedGenderCharacter = new();
        selectedEyeColorCharacter = new();
        selectedHairColorCharacter = new();
        selectedMentalityCharacter = new();
        selectedProfessionCharacter = new();
        selectedNatureCharacter = new();
        selectedStatCharacter = new();

        characteristicsName = "CreateCharacterAppearance";
        numberStatsChange = 4;

#if DEBUG
        MyLogger.logger.LogInformation($"Инициализация характеристик поумолчанию - {сharacterСharacteristics.img}," +
            $" {сharacterСharacteristics.gender}, {сharacterСharacteristics.eyeColor}, {сharacterСharacteristics.hairColor}, " +
            $"{сharacterСharacteristics.mentality}, {сharacterСharacteristics.profession}, {сharacterСharacteristics.character}, " +
            $"{сharacterСharacteristics.strength}, {сharacterСharacteristics.agiluty}, {сharacterСharacteristics.intelligence}," +
            $"{сharacterСharacteristics.fortune}, {сharacterСharacteristics.character}.");
#endif
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void ChangeGenderBtn_Clicked(object sender, EventArgs e)
    {
#if DEBUG
        MyLogger.logger.LogInformation("Событие: cмена пола персонажа.");
#endif
        NewSelectedGenderFromStruct();
        ChangeGenderLabel();
        ChangeCharacterImg();
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void NewSelectedGenderFromStruct()
    {
        сharacterСharacteristics.gender = selectedGenderCharacter.SelectedGender(сharacterСharacteristics.gender);
    }
    private void ChangeGenderLabel()
    {
        SelectedGender.Text = selectedGenderCharacter.NewTextGender(SelectLanguage.language, сharacterСharacteristics.gender);
#if DEBUG
        MyLogger.logger.LogInformation($"Выбран новый пол - {SelectedGender.Text}.");
#endif
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void ChangeEyeColorBtn_Clicked(object sender, EventArgs e)
    {
#if DEBUG
        MyLogger.logger.LogInformation("Событие: cмена цвета глаз персонажа.");
#endif
        Button clickedButton = (Button)sender;

        if (clickedButton.Text == "-") NewSelectedEyeColorFromStruct("left");
        else NewSelectedEyeColorFromStruct("right");

        ChangeEyeColorLabel();
        ChangeCharacterImg();
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void NewSelectedEyeColorFromStruct(string leftOrRightBtn)
    {
        сharacterСharacteristics.eyeColor = selectedEyeColorCharacter.SelectedEyeColor(сharacterСharacteristics.eyeColor, leftOrRightBtn);
    }
    private void ChangeEyeColorLabel()
    {
        SelectedEyeColor.Text = selectedEyeColorCharacter.NewTextEyeColor(SelectLanguage.language, сharacterСharacteristics.eyeColor);
#if DEBUG
        MyLogger.logger.LogInformation($"Выбран новый цвет глаз - {SelectedEyeColor.Text}.");
#endif
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void ChangeHairColorBtn_Clicked(object sender, EventArgs e)
    {
#if DEBUG
        MyLogger.logger.LogInformation("Событие: cмена цвета волос персонажа.");
#endif
        Button clickedButton = (Button)sender;

        if (clickedButton.Text == "-") NewSelectedHairColorFromStruct("left");
        else NewSelectedHairColorFromStruct("right");

        ChangeHairColorLabel();
        ChangeCharacterImg();
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void NewSelectedHairColorFromStruct(string leftOrRight)
    {
        сharacterСharacteristics.hairColor = selectedHairColorCharacter.SelectedHairColor(сharacterСharacteristics.hairColor, leftOrRight);
    }
    private void ChangeHairColorLabel()
    {
        SelectedHairColor.Text = selectedHairColorCharacter.NewTextHairColor(SelectLanguage.language, сharacterСharacteristics.hairColor);
#if DEBUG
        MyLogger.logger.LogInformation($"Выбран новый цвет волос - {SelectedHairColor.Text}.");
#endif
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void ChangeCharacterImg()
    {
#if DEBUG
        MyLogger.logger.LogInformation("Изменение картинки персонажа.");
#endif
        if (сharacterСharacteristics.gender == GenderEnum.Female && сharacterСharacteristics.eyeColor == EyeColorEnum.Brown
            && сharacterСharacteristics.hairColor == HairColorEnum.Ginger)
        {
            сharacterСharacteristics.img = ImgCharacterEnum.FemaleBrownGinger;
            ImageMainCharacter.Source = "femalebrownginger.png";
        }
        else if (сharacterСharacteristics.gender == GenderEnum.Female && сharacterСharacteristics.eyeColor == EyeColorEnum.Brown
            && сharacterСharacteristics.hairColor == HairColorEnum.Black)
        {
            сharacterСharacteristics.img = ImgCharacterEnum.FemaleBrownBlack;
            ImageMainCharacter.Source = "femalebrownblack.png";
        }
        else if (сharacterСharacteristics.gender == GenderEnum.Female && сharacterСharacteristics.eyeColor == EyeColorEnum.Brown
            && сharacterСharacteristics.hairColor == HairColorEnum.Blonde)
        {
            сharacterСharacteristics.img = ImgCharacterEnum.FemaleBrownBlonde;
            ImageMainCharacter.Source = "femalebrownblonde.png";
        }
        else if (сharacterСharacteristics.gender == GenderEnum.Female && сharacterСharacteristics.eyeColor == EyeColorEnum.Blue
            && сharacterСharacteristics.hairColor == HairColorEnum.Ginger)
        {
            сharacterСharacteristics.img = ImgCharacterEnum.FemaleBlueGinger;
            ImageMainCharacter.Source = "femaleblueginger.png";
        }
        else if (сharacterСharacteristics.gender == GenderEnum.Female && сharacterСharacteristics.eyeColor == EyeColorEnum.Blue
            && сharacterСharacteristics.hairColor == HairColorEnum.Black)
        {
            сharacterСharacteristics.img = ImgCharacterEnum.FemaleBlueBlack;
            ImageMainCharacter.Source = "femaleblueblack.png";
        }
        else if (сharacterСharacteristics.gender == GenderEnum.Female && сharacterСharacteristics.eyeColor == EyeColorEnum.Blue
            && сharacterСharacteristics.hairColor == HairColorEnum.Blonde)
        {
            сharacterСharacteristics.img = ImgCharacterEnum.FemaleBlueBlonde;
            ImageMainCharacter.Source = "femaleblueblonde.png";
        }
        else if (сharacterСharacteristics.gender == GenderEnum.Female && сharacterСharacteristics.eyeColor == EyeColorEnum.Green
            && сharacterСharacteristics.hairColor == HairColorEnum.Ginger)
        {
            сharacterСharacteristics.img = ImgCharacterEnum.FemaleGreenGinger;
            ImageMainCharacter.Source = "femalegreenginger.png";
        }
        else if (сharacterСharacteristics.gender == GenderEnum.Female && сharacterСharacteristics.eyeColor == EyeColorEnum.Green
            && сharacterСharacteristics.hairColor == HairColorEnum.Black)
        {
            сharacterСharacteristics.img = ImgCharacterEnum.FemaleGreenBlack;
            ImageMainCharacter.Source = "femalegreenblack.png";
        }
        else if (сharacterСharacteristics.gender == GenderEnum.Female && сharacterСharacteristics.eyeColor == EyeColorEnum.Green
            && сharacterСharacteristics.hairColor == HairColorEnum.Blonde)
        {
            сharacterСharacteristics.img = ImgCharacterEnum.FemaleGreenBlonde;
            ImageMainCharacter.Source = "femalegreenblonde.png";
        }
        else if (сharacterСharacteristics.gender == GenderEnum.Male && сharacterСharacteristics.eyeColor == EyeColorEnum.Brown
            && сharacterСharacteristics.hairColor == HairColorEnum.Ginger)
        {
            сharacterСharacteristics.img = ImgCharacterEnum.FemaleBrownGinger;
            ImageMainCharacter.Source = "malebrownginger.png";
        }
        else if (сharacterСharacteristics.gender == GenderEnum.Male && сharacterСharacteristics.eyeColor == EyeColorEnum.Brown
            && сharacterСharacteristics.hairColor == HairColorEnum.Black)
        {
            сharacterСharacteristics.img = ImgCharacterEnum.FemaleBrownBlack;
            ImageMainCharacter.Source = "malebrownblack.png";
        }
        else if (сharacterСharacteristics.gender == GenderEnum.Male && сharacterСharacteristics.eyeColor == EyeColorEnum.Brown
            && сharacterСharacteristics.hairColor == HairColorEnum.Blonde)
        {
            сharacterСharacteristics.img = ImgCharacterEnum.FemaleBrownBlonde;
            ImageMainCharacter.Source = "malebrownblonde.png";
        }
        else if (сharacterСharacteristics.gender == GenderEnum.Male && сharacterСharacteristics.eyeColor == EyeColorEnum.Blue
            && сharacterСharacteristics.hairColor == HairColorEnum.Ginger)
        {
            сharacterСharacteristics.img = ImgCharacterEnum.FemaleBlueGinger;
            ImageMainCharacter.Source = "maleblueginger.png";
        }
        else if (сharacterСharacteristics.gender == GenderEnum.Male && сharacterСharacteristics.eyeColor == EyeColorEnum.Blue
            && сharacterСharacteristics.hairColor == HairColorEnum.Black)
        {
            сharacterСharacteristics.img = ImgCharacterEnum.FemaleBlueBlack;
            ImageMainCharacter.Source = "maleblueblack.png";
        }
        else if (сharacterСharacteristics.gender == GenderEnum.Male && сharacterСharacteristics.eyeColor == EyeColorEnum.Blue
            && сharacterСharacteristics.hairColor == HairColorEnum.Blonde)
        {
            сharacterСharacteristics.img = ImgCharacterEnum.FemaleBlueBlonde;
            ImageMainCharacter.Source = "maleblueblonde.png";
        }
        else if (сharacterСharacteristics.gender == GenderEnum.Male && сharacterСharacteristics.eyeColor == EyeColorEnum.Green
            && сharacterСharacteristics.hairColor == HairColorEnum.Ginger)
        {
            сharacterСharacteristics.img = ImgCharacterEnum.FemaleGreenGinger;
            ImageMainCharacter.Source = "malegreenginger.png";
        }
        else if (сharacterСharacteristics.gender == GenderEnum.Male && сharacterСharacteristics.eyeColor == EyeColorEnum.Green
            && сharacterСharacteristics.hairColor == HairColorEnum.Black)
        {
            сharacterСharacteristics.img = ImgCharacterEnum.FemaleGreenBlack;
            ImageMainCharacter.Source = "malegreenblack.png";
        }
        else if (сharacterСharacteristics.gender == GenderEnum.Male && сharacterСharacteristics.eyeColor == EyeColorEnum.Green
            && сharacterСharacteristics.hairColor == HairColorEnum.Blonde)
        {
            сharacterСharacteristics.img = ImgCharacterEnum.FemaleGreenBlonde;
            ImageMainCharacter.Source = "malegreenblonde.png";
        }
#if DEBUG
        MyLogger.logger.LogInformation($"Картинка изменена на - {сharacterСharacteristics.img}.");
#endif
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void ChangeMentalityBtn_Clicked(object sender, EventArgs e)
    {
#if DEBUG
        MyLogger.logger.LogInformation("Событие: cмена склада ума персонажа.");
#endif
        Button clickedButton = (Button)sender;

        if (clickedButton.Text == "-") NewSelectedMentalityFromStruct("left");
        else NewSelectedMentalityFromStruct("right");

        ChangeMentalityLabel();
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void NewSelectedMentalityFromStruct(string leftOrRightBtn)
    {
        сharacterСharacteristics.mentality = selectedMentalityCharacter.SelectedMentality(сharacterСharacteristics.mentality, leftOrRightBtn);
    }
    private void ChangeMentalityLabel()
    {
        SelectedMentality.Text = selectedMentalityCharacter.NewTextMentality(SelectLanguage.language, сharacterСharacteristics.mentality);
#if DEBUG
        MyLogger.logger.LogInformation($"Выбран новый склад ума - {SelectedMentality.Text}.");
#endif
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void ChangeProfessionBtn_Clicked(object sender, EventArgs e)
    {
#if DEBUG
        MyLogger.logger.LogInformation("Событие: cмена профессии персонажа.");
#endif
        Button clickedButton = (Button)sender;

        if (clickedButton.Text == "-") NewSelectedProfessionFromStruct("left");
        else NewSelectedProfessionFromStruct("right");

        ChangeProfessionLabel();
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void NewSelectedProfessionFromStruct(string leftOrRightBtn)
    {
        сharacterСharacteristics.profession = selectedProfessionCharacter.SelectedProfession(сharacterСharacteristics.profession, leftOrRightBtn);
    }
    private void ChangeProfessionLabel()
    {
        SelectedProfession.Text = selectedProfessionCharacter.NewTextProfession(SelectLanguage.language, сharacterСharacteristics.profession);
#if DEBUG
        MyLogger.logger.LogInformation($"Выбрана новая профессия - {SelectedProfession.Text}.");
#endif
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void ChangeCharacterBtn_Clicked(object sender, EventArgs e)
    {
#if DEBUG
        MyLogger.logger.LogInformation("Событие: cмена характера персонажа.");
#endif
        Button clickedButton = (Button)sender;

        if (clickedButton.Text == "-") NewSelectedCharacterFromStruct("left");
        else NewSelectedCharacterFromStruct("right");

        ChangeCharacterLabel();
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void NewSelectedCharacterFromStruct(string leftOrRightBtn)
    {
        сharacterСharacteristics.character = selectedNatureCharacter.SelectedСharacter(сharacterСharacteristics.character, leftOrRightBtn);
    }
    private void ChangeCharacterLabel()
    {
        SelectedCharacter.Text = selectedNatureCharacter.NewTextСharacter(SelectLanguage.language, сharacterСharacteristics.character);
#if DEBUG
        MyLogger.logger.LogInformation($"Выбран новый характер - {SelectedCharacter.Text}.");
#endif
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void ChangeStrengthBtn_Clicked(object sender, EventArgs e)
    {
#if DEBUG
        MyLogger.logger.LogInformation("Событие: cмена характеристики(сила) персонажа.");
#endif
        Button clickedButton = (Button)sender;

        if (clickedButton.Text == "-") { NewSelectedStrengthFromStruct("left"); numberStatsChange++; }
        else { NewSelectedStrengthFromStruct("right"); numberStatsChange--; }

        ChangeStrengthLabel();
        CheckingValueStrenght();
        CheckingAllStat();
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void NewSelectedStrengthFromStruct(string leftOrRight)
    {
        сharacterСharacteristics.strength = selectedStatCharacter.SelectedStat(сharacterСharacteristics.strength, leftOrRight);
    }
    private void ChangeStrengthLabel()
    {
        SelectedStrength.Text = сharacterСharacteristics.strength.ToString();
#if DEBUG
        MyLogger.logger.LogInformation($"Изменение: сила - {SelectedStrength.Text}.");
#endif
    }
    private void CheckingValueStrenght()
    {
        if (SelectedStrength.Text == "0") LeftStrengthBtn.IsEnabled = false;
        else if (SelectedStrength.Text == "3") RightStrengthBtn.IsEnabled = false;
        else { LeftStrengthBtn.IsEnabled = true; RightStrengthBtn.IsEnabled = true; }
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void ChangeAgilityBtn_Clicked(object sender, EventArgs e)
    {
#if DEBUG
        MyLogger.logger.LogInformation("Событие: cмена характеристики(ловкость) персонажа.");
#endif
        Button clickedButton = (Button)sender;

        if (clickedButton.Text == "-") { NewSelectedAgilityFromStruct("left"); numberStatsChange++; }
        else { NewSelectedAgilityFromStruct("right"); numberStatsChange--; }

        ChangeAgilityLabel();
        CheckingValueAgility();
        CheckingAllStat();
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void NewSelectedAgilityFromStruct(string leftOrRight)
    {
        сharacterСharacteristics.agiluty = selectedStatCharacter.SelectedStat(сharacterСharacteristics.agiluty, leftOrRight);
    }
    private void ChangeAgilityLabel()
    {
        SelectedAgility.Text = сharacterСharacteristics.agiluty.ToString();
#if DEBUG
        MyLogger.logger.LogInformation($"Изменение: ловкость - {SelectedAgility.Text}.");
#endif
    }
    private void CheckingValueAgility()
    {
        if (SelectedAgility.Text == "0") LeftAgilityBtn.IsEnabled = false;
        else if (SelectedAgility.Text == "3") RightAgilityBtn.IsEnabled = false;
        else { LeftAgilityBtn.IsEnabled = true; RightAgilityBtn.IsEnabled = true; }
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void ChangeIntelligenceBtn_Clicked(object sender, EventArgs e)
    {
#if DEBUG
        MyLogger.logger.LogInformation("Событие: cмена характеристики(интеллект) персонажа.");
#endif
        Button clickedButton = (Button)sender;

        if (clickedButton.Text == "-") { NewSelectedIntelligenceFromStruct("left"); numberStatsChange++; }
        else { NewSelectedIntelligenceFromStruct("right"); numberStatsChange--; }

        ChangeIntelligenceLabel();
        CheckingValueIntelligence();
        CheckingAllStat();
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void NewSelectedIntelligenceFromStruct(string leftOrRight)
    {
        сharacterСharacteristics.intelligence = selectedStatCharacter.SelectedStat(сharacterСharacteristics.intelligence, leftOrRight);
    }
    private void ChangeIntelligenceLabel()
    {
        SelectedIntelligence.Text = сharacterСharacteristics.intelligence.ToString();
#if DEBUG
        MyLogger.logger.LogInformation($"Изменение: интеллект - {SelectedIntelligence.Text}.");
#endif
    }
    private void CheckingValueIntelligence()
    {
        if (SelectedIntelligence.Text == "0") LeftIntelligenceBtn.IsEnabled = false;
        else if (SelectedIntelligence.Text == "3") RightIntelligenceBtn.IsEnabled = false;
        else { LeftIntelligenceBtn.IsEnabled = true; RightIntelligenceBtn.IsEnabled = true; }
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void ChangeFortuneBtn_Clicked(object sender, EventArgs e)
    {
#if DEBUG
        MyLogger.logger.LogInformation("Событие: cмена характеристики(удача) персонажа.");
#endif
        Button clickedButton = (Button)sender;

        if (clickedButton.Text == "-") { NewSelectedFortuneFromStruct("left"); numberStatsChange++; }
        else { NewSelectedFortuneFromStruct("right"); numberStatsChange--; }

        ChangeFortuneLabel();
        CheckingValueFortune();
        CheckingAllStat();
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void NewSelectedFortuneFromStruct(string leftOrRight)
    {
        сharacterСharacteristics.fortune = selectedStatCharacter.SelectedStat(сharacterСharacteristics.fortune, leftOrRight);
    }
    private void ChangeFortuneLabel()
    {
        SelectedFortune.Text = сharacterСharacteristics.fortune.ToString();
#if DEBUG
        MyLogger.logger.LogInformation($"Изменение: удача - {SelectedFortune.Text}.");
#endif
    }
    private void CheckingValueFortune()
    {
        if (SelectedFortune.Text == "0") LeftFortuneBtn.IsEnabled = false;
        else if (SelectedFortune.Text == "3") RightFortuneBtn.IsEnabled = false;
        else { LeftFortuneBtn.IsEnabled = true; RightFortuneBtn.IsEnabled = true; }
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private bool CheckingAllStat()
    {
        ChangeStatsLabel();

        if (numberStatsChange == 0)
        {
            RightStrengthBtn.IsEnabled = false;
            RightAgilityBtn.IsEnabled = false;
            RightIntelligenceBtn.IsEnabled = false;
            RightFortuneBtn.IsEnabled = false;

            return false;
        }

        else
        {
            if (сharacterСharacteristics.strength != 3) RightStrengthBtn.IsEnabled = true;
            if (сharacterСharacteristics.agiluty != 3) RightAgilityBtn.IsEnabled = true;
            if (сharacterСharacteristics.intelligence != 3) RightIntelligenceBtn.IsEnabled = true;
            if (сharacterСharacteristics.fortune != 3) RightFortuneBtn.IsEnabled = true;

            return true;
        }
    }
    private void ChangeStatsLabel()
    {
        string oldText = CreateCharacterStatsLabel.Text;
        string newText = oldText.Remove(oldText.Length - 1);
        CreateCharacterStatsLabel.Text = newText + $"{numberStatsChange}";
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void CloseKeyboard_Clicked(object sender, EventArgs e)
    {
        NameEntry.IsEnabled = false;
        NameEntry.IsEnabled = true;
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void NextBtn_Clicked(object sender, EventArgs e)
    {
        if (!CheckProcessBusy.isProcessBusy)
        {
#if DEBUG
            MyLogger.logger.LogInformation("Кнопка перехода далее нажата.");
#endif
            CheckProcessBusy.isProcessBusy = true;
            if (characteristicsName == "CreateCharacterAppearance") CreateCharacterAppearancePanelNext();
            else if (characteristicsName == "CreateCharacterNature") CreateCharacterNaturePanelNext();
            else if (characteristicsName == "CreateCharacterStats")
            {
                CreateCharacterStatsPanelNext();
                ChangeNextButton();
            }
            CheckProcessBusy.isProcessBusy = false;

            return;
        }
#if DEBUG
        MyLogger.logger.LogInformation("Кнопка перехода далее занята!");
#endif
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void CreateCharacterAppearancePanelNext()
    {
        CreateCharacterAppearanceLabel.IsVisible = false;
        GenderLabel.IsVisible = false;
        GenderStack.IsVisible = false;
        EyeColorLabel.IsVisible = false;
        EyeColorStack.IsVisible = false;
        HairColorLabel.IsVisible = false;
        HairColorStack.IsVisible = false;

        CreateCharacterNatureLabel.IsVisible = true;
        MentalityLabel.IsVisible = true;
        MentalityStack.IsVisible = true;
        ProfessionLabel.IsVisible = true;
        ProfessionStack.IsVisible = true;
        CharacterLabel.IsVisible = true;
        CharacterStack.IsVisible = true;

        characteristicsName = "CreateCharacterNature";
    }
    private void CreateCharacterNaturePanelNext()
    {
        CreateCharacterNatureLabel.IsVisible = false;
        MentalityLabel.IsVisible = false;
        MentalityStack.IsVisible = false;
        ProfessionLabel.IsVisible = false;
        ProfessionStack.IsVisible = false;
        CharacterLabel.IsVisible = false;
        CharacterStack.IsVisible = false;

        CreateCharacterStatsLabel.IsVisible = true;
        StrengthLabel.IsVisible = true;
        StrengthStack.IsVisible = true;
        AgilityLabel.IsVisible = true;
        AgilityStack.IsVisible = true;
        IntelligenceLabel.IsVisible = true;
        IntelligenceStack.IsVisible = true;
        FortuneLabel.IsVisible = true;
        FortuneStack.IsVisible = true;

        characteristicsName = "CreateCharacterStats";
    }
    private void CreateCharacterStatsPanelNext()
    {
        CreateCharacterStatsLabel.IsVisible = false;
        StrengthLabel.IsVisible = false;
        StrengthStack.IsVisible = false;
        AgilityLabel.IsVisible = false;
        AgilityStack.IsVisible = false;
        IntelligenceLabel.IsVisible = false;
        IntelligenceStack.IsVisible = false;
        FortuneLabel.IsVisible = false;
        FortuneStack.IsVisible = false;

        CreateCharacterNameLabel.IsVisible = true;
        NameEntry.IsVisible = true;

        characteristicsName = "CreateCharacterName";
    }
    private void ChangeNextButton()
    {
        NextBtn.IsVisible = false;
        StartAdventureBtn.IsVisible = true;
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private bool CheckNameCharacter()
    {
#if DEBUG
        MyLogger.logger.LogInformation("Проверка имени персонажа - начата.");
#endif
        Regex regex = new Regex(@"[а-яА-Яa-zA-Z]");

        if (NameEntry.Text != null && regex.IsMatch(NameEntry.Text)) return true;

        else return false;
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private async void BackBtn_Clicked(object sender, EventArgs e)
    {
        if (!CheckProcessBusy.isProcessBusy)
        {
#if DEBUG
            MyLogger.logger.LogInformation("Кнопка перехода назад нажата.");
#endif
            CheckProcessBusy.isProcessBusy = true;
            if (characteristicsName == "CreateCharacterAppearance") await Navigation.PopModalAsync();
            else if (characteristicsName == "CreateCharacterNature") CreateCharacterAppearancePanelBack();
            else if (characteristicsName == "CreateCharacterStats") CreateCharacterNaturePanelBack();
            else if (characteristicsName == "CreateCharacterName")
            {
                CreateCharacterStatsPanelBack();
                ChangeNextButtonFromBack();
            }
            CheckProcessBusy.isProcessBusy = false;

            return;
        }
#if DEBUG
        MyLogger.logger.LogInformation("Кнопка перехода назад занята!");
#endif
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void CreateCharacterAppearancePanelBack()
    {
        CreateCharacterNatureLabel.IsVisible = false;
        MentalityLabel.IsVisible = false;
        MentalityStack.IsVisible = false;
        ProfessionLabel.IsVisible = false;
        ProfessionStack.IsVisible = false;
        CharacterLabel.IsVisible = false;
        CharacterStack.IsVisible = false;

        CreateCharacterAppearanceLabel.IsVisible = true;
        GenderLabel.IsVisible = true;
        GenderStack.IsVisible = true;
        EyeColorLabel.IsVisible = true;
        EyeColorStack.IsVisible = true;
        HairColorLabel.IsVisible = true;
        HairColorStack.IsVisible = true;

        characteristicsName = "CreateCharacterAppearance";
    }
    private void CreateCharacterNaturePanelBack()
    {
        CreateCharacterStatsLabel.IsVisible = false;
        StrengthLabel.IsVisible = false;
        StrengthStack.IsVisible = false;
        AgilityLabel.IsVisible = false;
        AgilityStack.IsVisible = false;
        IntelligenceLabel.IsVisible = false;
        IntelligenceStack.IsVisible = false;
        FortuneLabel.IsVisible = false;
        FortuneStack.IsVisible = false;

        CreateCharacterNatureLabel.IsVisible = true;
        MentalityLabel.IsVisible = true;
        MentalityStack.IsVisible = true;
        ProfessionLabel.IsVisible = true;
        ProfessionStack.IsVisible = true;
        CharacterLabel.IsVisible = true;
        CharacterStack.IsVisible = true;

        characteristicsName = "CreateCharacterNature";
    }
    private void CreateCharacterStatsPanelBack()
    {
        CreateCharacterStatsLabel.IsVisible = true;
        StrengthLabel.IsVisible = true;
        StrengthStack.IsVisible = true;
        AgilityLabel.IsVisible = true;
        AgilityStack.IsVisible = true;
        IntelligenceLabel.IsVisible = true;
        IntelligenceStack.IsVisible = true;
        FortuneLabel.IsVisible = true;
        FortuneStack.IsVisible = true;

        CreateCharacterNameLabel.IsVisible = false;
        NameEntry.IsVisible = false;

        characteristicsName = "CreateCharacterStats";
    }
    private void ChangeNextButtonFromBack()
    {
        NextBtn.IsVisible = true;
        StartAdventureBtn.IsVisible = false;
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void StartAdventureBtn_Clicked(object sender, EventArgs e)
    {
        if (characteristicsName == "CreateCharacterName")
        {
            if (CheckNameCharacter())
            {
                SetNameFromStruct();
                SaveCharacterFromFile();
                StartGamePage();
            }
            else NameError();
        }
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void SetNameFromStruct()
    {
        сharacterСharacteristics.characterName = NameEntry.Text;
#if DEBUG
        MyLogger.logger.LogInformation($"Имя персонажа успешно записано - {сharacterСharacteristics.characterName}.");
#endif
    }
    private void NameError()
    {
#if DEBUG
        MyLogger.logger.LogInformation($"Неверное имя персонажа.");
#endif
        if (characterCreation_Ru != null) DisplayAlert("Некорректное имя", "В имени должна присутствовать хотя бы одна буква!", "Ок");
        else if (characterCreation_En != null) DisplayAlert("Incorrect name", "The name must contain at least one letter!", "Ok");
        else DisplayAlert("Incorrect name", "The name must contain at least one letter!", "Ok");
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void SaveCharacterFromFile()
    {
        new SaveCharacterFromStruct(сharacterСharacteristics);
    }
    private async void StartGamePage()
    {
        if (!CheckProcessBusy.isProcessBusy)
        {
#if DEBUG
            MyLogger.logger.LogInformation("Переход на страницу игры - успешен.");
#endif
            CheckProcessBusy.isProcessBusy = true;
            loadGameBtn.IsVisible = true;
            loadingIndicator.IsRunning = true;
            await Navigation.PushModalAsync(new GamePage(this));
            loadingIndicator.IsRunning = false;
            CheckProcessBusy.isProcessBusy = false;

            return;
        }
#if DEBUG
        MyLogger.logger.LogInformation("Кнопка открытия страницы игры - занята!");
#endif
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    public async Task BackGamePage()
    {
        await Navigation.PopModalAsync(false);
#if DEBUG
        MyLogger.logger.LogInformation("Переход на страницу выбора одиночной игры - успешен.");
#endif
    }
    //----------------------------------------------------------------------------------------------------------------------------------
}
//--------------------------------------------------------------------------------------------------------------------------------------