//Класс для создания персонажа игрока
//--------------------------------------------------------------------------------------------------------------------------------------

namespace QuantumJourneys.Pages.СharacterCreation;

//--------------------------------------------------------------------------------------------------------------------------------------
public partial class CharacterCreationPage : ContentPage
{
    //----------------------------------------------------------------------------------------------------------------------------------

    private string language;
    private string characteristicsName;
    private int numberStatsChange;

    private СharacterСharacteristics сharacterСharacteristics;
    private SelectedGenderСharacter selectedGenderCharacter;
    private SelectedEyeColorCharacter selectedEyeColorCharacter;
    private SelectedHairColorCharacter selectedHairColorCharacter;
    private SelectedMentalityCharacter selectedMentalityCharacter;
    private SelectedProfessionCharacter selectedProfessionCharacter;
    private SelectedNatureCharacter selectedNatureCharacter;
    private SelectedStatCharacter selectedStatCharacter;

    //----------------------------------------------------------------------------------------------------------------------------------
    public CharacterCreationPage(string selectedLanguage)
	{
		InitializeComponent();
        InitLanguage(selectedLanguage);
        InitDefaultCharacteristics();
	}
    private void InitLanguage(string language)
    {
        switch (language)
        {
            case "Ru":
                new CharacterCreation_Ru(this);
                break;

            case "En":
                new CharacterCreation_En(this);
                break;

            default:
                new CharacterCreation_En(this);
                break;
        }

        this.language= language;
    }
    private void InitDefaultCharacteristics()
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

        selectedGenderCharacter = new();
        selectedEyeColorCharacter = new();
        selectedHairColorCharacter = new();
        selectedMentalityCharacter = new();
        selectedProfessionCharacter = new();
        selectedNatureCharacter = new();
        selectedStatCharacter = new();

        characteristicsName = "CreateCharacterAppearance";
        numberStatsChange = 4;
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void ChangeGenderBtn_Clicked(object sender, EventArgs e)
    {
        NewSelectedGenderFromStruct();
        ChangeGenderLabel();
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void NewSelectedGenderFromStruct()
    {
        сharacterСharacteristics.gender = selectedGenderCharacter.SelectedGender(сharacterСharacteristics.gender);
    }
    private void ChangeGenderLabel()
    {
        SelectedGender.Text = selectedGenderCharacter.NewTextGender(language, сharacterСharacteristics.gender);
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void ChangeEyeColorBtn_Clicked(object sender, EventArgs e)
    {
        Button clickedButton = (Button)sender;

        if (clickedButton.Text == "-") NewSelectedEyeColorFromStruct("left");
        else NewSelectedEyeColorFromStruct("right");

        ChangeEyeColorLabel();
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void NewSelectedEyeColorFromStruct(string leftOrRightBtn)
    {
        сharacterСharacteristics.eyeColor = selectedEyeColorCharacter.SelectedEyeColor(сharacterСharacteristics.eyeColor, leftOrRightBtn);
    }
    private void ChangeEyeColorLabel()
    {
        SelectedEyeColor.Text = selectedEyeColorCharacter.NewTextEyeColor(language, сharacterСharacteristics.eyeColor);
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void ChangeHairColorBtn_Clicked(object sender, EventArgs e)
    {
        Button clickedButton = (Button)sender;

        if (clickedButton.Text == "-") NewSelectedHairColorFromStruct("left");
        else NewSelectedHairColorFromStruct("right");

        ChangeHairColorLabel();
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void NewSelectedHairColorFromStruct(string leftOrRight)
    {
        сharacterСharacteristics.hairColor = selectedHairColorCharacter.SelectedHairColor(сharacterСharacteristics.hairColor, leftOrRight);
    }
    private void ChangeHairColorLabel()
    {
        SelectedHairColor.Text = selectedHairColorCharacter.NewTextHairColor(language, сharacterСharacteristics.hairColor);
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void ChangeMentalityBtn_Clicked(object sender, EventArgs e)
    {
        Button clickedButton = (Button)sender;

        if (clickedButton.Text == "-") NewSelectedMentalityFromStruct("left");
        else NewSelectedMentalityFromStruct("right");

        ChangeMentalityLabel();
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void NewSelectedMentalityFromStruct(string leftOrRightBtn)
    {
        сharacterСharacteristics.mentality= selectedMentalityCharacter.SelectedMentality(сharacterСharacteristics.mentality, leftOrRightBtn);
    }
    private void ChangeMentalityLabel()
    {
        SelectedMentality.Text = selectedMentalityCharacter.NewTextMentality(language, сharacterСharacteristics.mentality);
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void ChangeProfessionBtn_Clicked(object sender, EventArgs e)
    {
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
        SelectedProfession.Text = selectedProfessionCharacter.NewTextProfession(language, сharacterСharacteristics.profession);
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void ChangeCharacterBtn_Clicked(object sender, EventArgs e)
    {
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
        SelectedCharacter.Text = selectedNatureCharacter.NewTextСharacter(language, сharacterСharacteristics.character);
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private void ChangeStrengthBtn_Clicked(object sender, EventArgs e)
    {
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
    private void NextBtn_Clicked(object sender, EventArgs e)
    {
        if (characteristicsName == "CreateCharacterAppearance") CreateCharacterAppearancePanelNext();
        else if (characteristicsName == "CreateCharacterNature") CreateCharacterNaturePanelNext();
        else if (characteristicsName == "CreateCharacterStats") CreateCharacterStatsPanelNext();
        else if (characteristicsName == "CreateCharacterName") { }
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
        NameLabel.IsVisible = true;

        characteristicsName = "CreateCharacterName";
    }
    //----------------------------------------------------------------------------------------------------------------------------------
    private async void BackBtn_Clicked(object sender, EventArgs e)
    {
        if (characteristicsName == "CreateCharacterAppearance") await Navigation.PopModalAsync();
        else if (characteristicsName == "CreateCharacterNature") CreateCharacterAppearancePanelBack();
        else if (characteristicsName == "CreateCharacterStats") CreateCharacterNaturePanelBack();
        else if (characteristicsName == "CreateCharacterName") CreateCharacterStatsPanelBack();
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
        NameLabel.IsVisible = false;

        characteristicsName = "CreateCharacterStats";
    }
    //----------------------------------------------------------------------------------------------------------------------------------
}
//--------------------------------------------------------------------------------------------------------------------------------------