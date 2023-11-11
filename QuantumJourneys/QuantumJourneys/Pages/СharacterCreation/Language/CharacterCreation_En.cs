//Английский язык для страницы создания персонажа
//------------------------------------------------------------------------------------------------------------------------------------------
namespace QuantumJourneys.Pages.СharacterCreation.Language
{
    //--------------------------------------------------------------------------------------------------------------------------------------
    public class CharacterCreation_En
    {
        //----------------------------------------------------------------------------------------------------------------------------------
        public CharacterCreation_En(CharacterCreationPage characterCreationPage) 
        {
            Label CreateCharacterAppearanceLabel = (Label)characterCreationPage.FindByName("CreateCharacterAppearanceLabel");
            CreateCharacterAppearanceLabel.Text = "Choose your character's appearance";

            Label GenderLabel = (Label)characterCreationPage.FindByName("GenderLabel");
            GenderLabel.Text = "Gender";

            Label SelectedGender = (Label)characterCreationPage.FindByName("SelectedGender");
            SelectedGender.Text = "Male";

            Label EyeColorLabel = (Label)characterCreationPage.FindByName("EyeColorLabel");
            EyeColorLabel.Text = "Eye Color";

            Label SelectedEyeColor = (Label)characterCreationPage.FindByName("SelectedEyeColor");
            SelectedEyeColor.Text = "Brown";

            Label HairColorLabel = (Label)characterCreationPage.FindByName("HairColorLabel");
            HairColorLabel.Text = "Hair Color";

            Label SelectedHairColor = (Label)characterCreationPage.FindByName("SelectedHairColor");
            SelectedHairColor.Text = "Ginger";

            Label CreateCharacterNatureLabel = (Label)characterCreationPage.FindByName("CreateCharacterNatureLabel");
            CreateCharacterNatureLabel.Text = "Choose your character's personality";

            Label MentalityLabel = (Label)characterCreationPage.FindByName("MentalityLabel");
            MentalityLabel.Text = "Mentality";

            Label SelectedMentality = (Label)characterCreationPage.FindByName("SelectedMentality");
            SelectedMentality.Text = "Technical";

            Label ProfessionLabel = (Label)characterCreationPage.FindByName("ProfessionLabel");
            ProfessionLabel.Text = "Profession";

            Label SelectedProfession = (Label)characterCreationPage.FindByName("SelectedProfession");
            SelectedProfession.Text = "Teacher";

            Label CharacterLabel = (Label)characterCreationPage.FindByName("CharacterLabel");
            CharacterLabel.Text = "Nature";

            Label SelectedCharacter = (Label)characterCreationPage.FindByName("SelectedCharacter");
            SelectedCharacter.Text = "Choleric";

            Label CreateCharacterStatsLabel = (Label)characterCreationPage.FindByName("CreateCharacterStatsLabel");
            CreateCharacterStatsLabel.Text = "Select your character's basic options. Available: 4";

            Label StrengthLabel = (Label)characterCreationPage.FindByName("StrengthLabel");
            StrengthLabel.Text = "Strength";

            Label AgilityLabel = (Label)characterCreationPage.FindByName("AgilityLabel");
            AgilityLabel.Text = "Agility";

            Label IntelligenceLabel = (Label)characterCreationPage.FindByName("IntelligenceLabel");
            IntelligenceLabel.Text = "Intelligence";

            Label FortuneLabel = (Label)characterCreationPage.FindByName("FortuneLabel");
            FortuneLabel.Text = "Fortune";

            Label CreateCharacterNameLabel = (Label)characterCreationPage.FindByName("CreateCharacterNameLabel");
            CreateCharacterNameLabel.Text = "Character`s name";

            Entry NameEntry = (Entry)characterCreationPage.FindByName("NameEntry");
            NameEntry.Placeholder = "Choose a character name";

            Button BackBtn = (Button)characterCreationPage.FindByName("BackBtn");
            BackBtn.Text = "Back";

            Button NextBtn = (Button)characterCreationPage.FindByName("NextBtn");
            NextBtn.Text = "Next";
        }
        //----------------------------------------------------------------------------------------------------------------------------------
    }
    //--------------------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------------------
