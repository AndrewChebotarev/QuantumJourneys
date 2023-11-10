//Русский язык для страницы для создания персонажа
//------------------------------------------------------------------------------------------------------------------------------------------
namespace QuantumJourneys.Pages.СharacterCreation.Language
{
    //--------------------------------------------------------------------------------------------------------------------------------------
    public class CharacterCreation_Ru
    {
        //----------------------------------------------------------------------------------------------------------------------------------
        public CharacterCreation_Ru(CharacterCreationPage characterCreationPage)
        {
            Label CreateCharacterAppearanceLabel = (Label)characterCreationPage.FindByName("CreateCharacterAppearanceLabel");
            CreateCharacterAppearanceLabel.Text = "Выберите внешность перснонажа";

            Label GenderLabel = (Label)characterCreationPage.FindByName("GenderLabel");
            GenderLabel.Text = "Пол";

            Label SelectedGender = (Label)characterCreationPage.FindByName("SelectedGender");
            SelectedGender.Text = "Мужской";

            Label EyeColorLabel = (Label)characterCreationPage.FindByName("EyeColorLabel");
            EyeColorLabel.Text = "Цвет глаз";

            Label SelectedEyeColor = (Label)characterCreationPage.FindByName("SelectedEyeColor");
            SelectedEyeColor.Text = "Карие";

            Label HairColorLabel = (Label)characterCreationPage.FindByName("HairColorLabel");
            HairColorLabel.Text = "Цвет волос";

            Label SelectedHairColor = (Label)characterCreationPage.FindByName("SelectedHairColor");
            SelectedHairColor.Text = "Рыжий";

            Label CreateCharacterNatureLabel = (Label)characterCreationPage.FindByName("CreateCharacterNatureLabel");
            CreateCharacterNatureLabel.Text = "Выберите личность перснонажа";

            Label MentalityLabel = (Label)characterCreationPage.FindByName("MentalityLabel");
            MentalityLabel.Text = "Склад ума";

            Label SelectedMentality = (Label)characterCreationPage.FindByName("SelectedMentality");
            SelectedMentality.Text = "Технический";

            Label ProfessionLabel = (Label)characterCreationPage.FindByName("ProfessionLabel");
            ProfessionLabel.Text = "Профессия";

            Label SelectedProfession = (Label)characterCreationPage.FindByName("SelectedProfession");
            SelectedProfession.Text = "Учитель";

            Label CharacterLabel = (Label)characterCreationPage.FindByName("CharacterLabel");
            CharacterLabel.Text = "Характер";

            Label SelectedCharacter = (Label)characterCreationPage.FindByName("SelectedCharacter");
            SelectedCharacter.Text = "Холерик";

            Label CreateCharacterStatsLabel = (Label)characterCreationPage.FindByName("CreateCharacterStatsLabel");
            CreateCharacterStatsLabel.Text = "Выберите базовые параметры. Доступно: 4";

            Label StrengthLabel = (Label)characterCreationPage.FindByName("StrengthLabel");
            StrengthLabel.Text = "Сила";

            Label AgilityLabel = (Label)characterCreationPage.FindByName("AgilityLabel");
            AgilityLabel.Text = "Ловкость";

            Label IntelligenceLabel = (Label)characterCreationPage.FindByName("IntelligenceLabel");
            IntelligenceLabel.Text = "Интеллект";

            Label FortuneLabel = (Label)characterCreationPage.FindByName("FortuneLabel");
            FortuneLabel.Text = "Удача";

            Label CreateCharacterNameLabel = (Label)characterCreationPage.FindByName("CreateCharacterNameLabel");
            CreateCharacterNameLabel.Text = "Имя персонажа";

            Entry NameLabel = (Entry)characterCreationPage.FindByName("NameLabel");
            NameLabel.Placeholder = "Выберите имя персонажа";

            Button BackBtn = (Button)characterCreationPage.FindByName("BackBtn");
            BackBtn.Text = "Назад";

            Button NextBtn = (Button)characterCreationPage.FindByName("NextBtn");
            NextBtn.Text = "Далее";
        }
        //----------------------------------------------------------------------------------------------------------------------------------
    }
    //--------------------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------------------
