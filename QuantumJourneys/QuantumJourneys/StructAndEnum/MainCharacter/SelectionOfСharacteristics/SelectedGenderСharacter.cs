//Класс для работы с полом персонажа игрока
//------------------------------------------------------------------------------------------------------------------------------------------
namespace QuantumJourneys.StructAndEnum.MainCharacter.SelectionOfСharacteristics
{
    //--------------------------------------------------------------------------------------------------------------------------------------
    public class SelectedGenderСharacter
    {
        //----------------------------------------------------------------------------------------------------------------------------------
        private Dictionary<GenderEnum, string> GenderDictonary_Ru = new()
        {
            { GenderEnum.Female, "Мужской" },
            { GenderEnum.Male, "Женский" }
        };
        private Dictionary<GenderEnum, string> GenderDictonary_En = new()
        {
            { GenderEnum.Female, "Female" },
            { GenderEnum.Male, "Male" }
        };
        //----------------------------------------------------------------------------------------------------------------------------------
        public GenderEnum SelectedGender(GenderEnum gender)
        {
            return gender switch
            {
                GenderEnum.Male => GenderEnum.Female,
                GenderEnum.Female => GenderEnum.Male,
                _ => GenderEnum.Female
            };
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        public string NewTextGender(string language, GenderEnum gender)
        {
            if (language == "Ru") return GenderDictonary_Ru[gender];
            else if (language == "En") return GenderDictonary_En[gender];
            else return GenderDictonary_En[gender];
        }
        //----------------------------------------------------------------------------------------------------------------------------------
    }
    //--------------------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------------------
