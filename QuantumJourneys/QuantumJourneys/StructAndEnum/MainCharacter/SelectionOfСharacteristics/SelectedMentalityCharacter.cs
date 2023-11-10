//Класс для работы с складом ума персонажа игрока
//------------------------------------------------------------------------------------------------------------------------------------------
namespace QuantumJourneys.StructAndEnum.MainCharacter.SelectionOfСharacteristics
{
    //--------------------------------------------------------------------------------------------------------------------------------------
    public class SelectedMentalityCharacter
    {
        //----------------------------------------------------------------------------------------------------------------------------------
        private Dictionary<MentalityEnum, string> MentalityDictonary_Ru = new()
        {
            { MentalityEnum.Technical, "Технический" },
            { MentalityEnum.Humanitarian, "Гуманитарный" },
            { MentalityEnum.Universal, "Универсальный"}
        };
        private Dictionary<MentalityEnum, string> MentalityDictonary_En = new()
        {
            { MentalityEnum.Technical, "Technical" },
            { MentalityEnum.Humanitarian, "Humanitarian" },
            { MentalityEnum.Universal, "Universal"}
        };
        //----------------------------------------------------------------------------------------------------------------------------------
        public MentalityEnum SelectedMentality(MentalityEnum mentality, string leftOrRight)
        {
            if (leftOrRight == "right")
                return mentality switch
                {
                    MentalityEnum.Technical => MentalityEnum.Humanitarian,
                    MentalityEnum.Humanitarian => MentalityEnum.Universal,
                    MentalityEnum.Universal => MentalityEnum.Technical,
                    _ => MentalityEnum.Technical
                };

            else
                return mentality switch
                {
                    MentalityEnum.Technical => MentalityEnum.Universal,
                    MentalityEnum.Universal => MentalityEnum.Humanitarian,
                    MentalityEnum.Humanitarian => MentalityEnum.Technical,
                    _ => MentalityEnum.Technical
                };
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        public string NewTextMentality(string language, MentalityEnum mentality)
        {
            if (language == "Ru") return MentalityDictonary_Ru[mentality];
            else if (language == "En") return MentalityDictonary_En[mentality];
            else return MentalityDictonary_En[mentality];
        }
        //----------------------------------------------------------------------------------------------------------------------------------
    }
    //--------------------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------------------
