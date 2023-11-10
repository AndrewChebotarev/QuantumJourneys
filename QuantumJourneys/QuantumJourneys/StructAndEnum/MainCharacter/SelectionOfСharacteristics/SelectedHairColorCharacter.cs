//Класс для работы с цветом волос для персонажа игрока
//------------------------------------------------------------------------------------------------------------------------------------------
namespace QuantumJourneys.StructAndEnum.MainCharacter.SelectionOfСharacteristics
{
    //--------------------------------------------------------------------------------------------------------------------------------------
    public class SelectedHairColorCharacter
    {
        //----------------------------------------------------------------------------------------------------------------------------------
        private Dictionary<HairColorEnum, string> HairColorDictonary_Ru = new()
        {
            { HairColorEnum.Ginger, "Рыжий" },
            { HairColorEnum.Black, "Черный" },
            { HairColorEnum.Blonde, "Светлый"}
        };
        private Dictionary<HairColorEnum, string> HairColorDictonary_En = new()
        {
            { HairColorEnum.Ginger, "Ginger" },
            { HairColorEnum.Black, "Black" },
            { HairColorEnum.Blonde, "Blonde"}
        };
        //----------------------------------------------------------------------------------------------------------------------------------
        public HairColorEnum SelectedHairColor(HairColorEnum hairColor, string leftOrRight)
        {
            if (leftOrRight == "right")
                return hairColor switch
                {
                    HairColorEnum.Ginger => HairColorEnum.Black,
                    HairColorEnum.Black => HairColorEnum.Blonde,
                    HairColorEnum.Blonde => HairColorEnum.Ginger,
                    _ => HairColorEnum.Ginger
                };

            else
                return hairColor switch
                {
                    HairColorEnum.Ginger => HairColorEnum.Blonde,
                    HairColorEnum.Blonde => HairColorEnum.Black,
                    HairColorEnum.Black => HairColorEnum.Ginger,
                    _ => HairColorEnum.Ginger
                };
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        public string NewTextHairColor(string language, HairColorEnum hairColor)
        {
            if (language == "Ru") return HairColorDictonary_Ru[hairColor];
            else if (language == "En") return HairColorDictonary_En[hairColor];
            else return HairColorDictonary_En[hairColor];
        }
        //----------------------------------------------------------------------------------------------------------------------------------
    }
    //--------------------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------------------
