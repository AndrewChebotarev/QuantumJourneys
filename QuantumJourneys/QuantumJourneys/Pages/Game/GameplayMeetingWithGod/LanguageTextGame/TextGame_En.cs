//Класс для передачи текста для игровой области - английский
//--------------------------------------------------------------------------------------------------------------------------------------
namespace QuantumJourneys.Pages.Game.GameplayMeetingWithGod.LanguageTextGame
{
    //----------------------------------------------------------------------------------------------------------------------------------
    public class TextGame_En
    {
        public List<string> SetTextGame()
        {
#if DEBUG
            MyLogger.logger.LogInformation("Инициализация игрового текста для UI английский - завершена.");
#endif
            return new List<string>
            {

            "You suddenly woke up in a small room that is completely painted in the purest white paint. The floor, walls and ceiling are all perfectly white.",

            "Button: Select1",
            "Button: Select2",
            "Button: Select3",
            "Button: Select4",

            "Text: test1",
            "Text: test2",

            "Button: Select5",
            "Button: Select6",
            "Button: Select7",
            "Button: Select8",

            "Text: test3",
            "Text: test3",
            "Text: test3",
            "Text: test3",

            "Button: Select5",
            "Button: Select6",
            "Button: Select7",
            "Button: Select8",

            "Text: test3",
            "Text: test3",
            "Text: test3",

            "Text: test3",
            "Text: test3",
            "Text: test3",
            "Text: test3",

            "Button: Select5",
            "Button: Select6",
            "Button: Select7",
            "Button: Select8",

            "Text: test3",
            "Text: test3",
            "Text: test3"

            };
        }
    }
    //----------------------------------------------------------------------------------------------------------------------------------
}
//--------------------------------------------------------------------------------------------------------------------------------------
