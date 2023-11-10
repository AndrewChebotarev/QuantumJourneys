//Класс для работы с характером персонажа игрока
//------------------------------------------------------------------------------------------------------------------------------------------
namespace QuantumJourneys.StructAndEnum.MainCharacter.SelectionOfСharacteristics
{
    //--------------------------------------------------------------------------------------------------------------------------------------
    public class SelectedNatureCharacter
    {
        //----------------------------------------------------------------------------------------------------------------------------------
        private Dictionary<СharacterEnum, string> СharacterDictonary_Ru = new()
        {
            { СharacterEnum.Choleric, "Холерик" },
            { СharacterEnum.Melancholic, "Меланхолик" },
            { СharacterEnum.Phlegmatic, "Флегматик"},
            { СharacterEnum.Sanguine, "Сангвиник"}
        };
        private Dictionary<СharacterEnum, string> СharacterDictonary_En = new()
        {
            { СharacterEnum.Choleric, "Choleric" },
            { СharacterEnum.Melancholic, "Melancholic" },
            { СharacterEnum.Phlegmatic, "Phlegmatic"},
            { СharacterEnum.Sanguine, "Sanguine"}
        };
        //----------------------------------------------------------------------------------------------------------------------------------
        public СharacterEnum SelectedСharacter(СharacterEnum character, string leftOrRight)
        {
            if (leftOrRight == "right")
                return character switch
                {
                    СharacterEnum.Choleric => СharacterEnum.Melancholic,
                    СharacterEnum.Melancholic => СharacterEnum.Phlegmatic,
                    СharacterEnum.Phlegmatic => СharacterEnum.Sanguine,
                    СharacterEnum.Sanguine => СharacterEnum.Choleric,
                    _ => СharacterEnum.Choleric
                };

            else
                return character switch
                {
                    СharacterEnum.Choleric => СharacterEnum.Sanguine,
                    СharacterEnum.Sanguine => СharacterEnum.Phlegmatic,
                    СharacterEnum.Phlegmatic => СharacterEnum.Melancholic,
                    СharacterEnum.Melancholic => СharacterEnum.Choleric,
                    _ => СharacterEnum.Choleric
                };
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        public string NewTextСharacter(string language, СharacterEnum character)
        {
            if (language == "Ru") return СharacterDictonary_Ru[character];
            else if (language == "En") return СharacterDictonary_En[character];
            else return СharacterDictonary_En[character];
        }
        //----------------------------------------------------------------------------------------------------------------------------------
    }
    //--------------------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------------------
