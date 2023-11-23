using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QuantumJourneys.Pages.Game.GameplayMeetingWithGod
{
    public class MeetingWithGodTextTransfer
    {
        private int counter = 0;

        private string[] Text_Ru = {

            "Вы внезапно очнулся в маленькой комнате, которая полностью окрашена в чистейшую белую краску. Пол, стены и потолок — все идеально белое.",

            "Button: Выбор1",
            "Button: Выбор2",
            "Button: Выбор3",
            "Button: Выбор4",

            "Text: тест1",
            "Text: тест2",

            "Button: Выбор5",
            "Button: Выбор6",
            "Button: Выбор7",
            "Button: Выбор8",

            "Text: тест3",
            "Text: тест3",
            "Text: тест3",
            "Text: тест3",

            "Button: Выбор5",
            "Button: Выбор6",
            "Button: Выбор7",
            "Button: Выбор8",

            "Text: тест3",
            "Text: тест3",
            "Text: тест3",

            "Text: тест3",
            "Text: тест3",
            "Text: тест3",
            "Text: тест3",

            "Button: Выбор5",
            "Button: Выбор6",
            "Button: Выбор7",
            "Button: Выбор8",

            "Text: тест3",
            "Text: тест3",
            "Text: тест3"
        };

        public string GiveFirstText()
        {
            counter++;
            return Text_Ru[0];
        }

        public StateGameUI GiveStateUi()
        {
            if (counter < Text_Ru.Length - 1 && Text_Ru[counter].StartsWith("Text: ")) return StateGameUI.label;
            else if (counter < Text_Ru.Length - 1 && Text_Ru[counter].StartsWith("Button: ")) return StateGameUI.button;
            else return StateGameUI.none;
        }

        public string GiveLabelText()
        {
            string text = Text_Ru[counter];
            counter++;
            return text.Substring("Text: ".Length);
        }

        public List<string> GiveButtonsText()
        {
            List<string> texts = new();

            for (int i = 0; i < 4; i++)
            {
                texts.Add(Text_Ru[counter].Substring("Button: ".Length));
                counter++;
            }

            return texts;
        }
    }
}
