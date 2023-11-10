//Класс для работы с цветом глаз персонажа игрока
//------------------------------------------------------------------------------------------------------------------------------------------
namespace QuantumJourneys.StructAndEnum.MainCharacter.SelectionOfСharacteristics
{
    //--------------------------------------------------------------------------------------------------------------------------------------
    public class SelectedEyeColorCharacter
    {
        //----------------------------------------------------------------------------------------------------------------------------------
        private Dictionary<EyeColorEnum, string> EyeColorDictonary_Ru = new()
        {
            { EyeColorEnum.Brown, "Карий" },
            { EyeColorEnum.Blue, "Голубой" },
            { EyeColorEnum.Green, "Зеленый"}
        };
        private Dictionary<EyeColorEnum, string> EyeColorDictonary_En = new()
        {
            { EyeColorEnum.Brown, "Brown" },
            { EyeColorEnum.Blue, "Blue" },
            { EyeColorEnum.Green, "Green"}
        };
        //----------------------------------------------------------------------------------------------------------------------------------
        public EyeColorEnum SelectedEyeColor(EyeColorEnum eyeColor, string leftOrRight)
        {
            if (leftOrRight == "right")
                return eyeColor switch
                {
                    EyeColorEnum.Brown => EyeColorEnum.Blue,
                    EyeColorEnum.Blue => EyeColorEnum.Green,
                    EyeColorEnum.Green => EyeColorEnum.Brown,
                    _ => EyeColorEnum.Brown
                };

            else
                return eyeColor switch
                {
                    EyeColorEnum.Brown => EyeColorEnum.Green,
                    EyeColorEnum.Green => EyeColorEnum.Blue,
                    EyeColorEnum.Blue => EyeColorEnum.Brown,
                    _ => EyeColorEnum.Brown
                };
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        public string NewTextEyeColor(string language, EyeColorEnum eyeColor)
        {
            if (language == "Ru") return EyeColorDictonary_Ru[eyeColor];
            else if (language == "En") return EyeColorDictonary_En[eyeColor];
            else return EyeColorDictonary_En[eyeColor];
        }
        //----------------------------------------------------------------------------------------------------------------------------------
    }
    //--------------------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------------------
