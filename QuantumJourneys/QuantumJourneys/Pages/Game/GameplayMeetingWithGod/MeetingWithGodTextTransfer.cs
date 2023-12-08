//Класс для передачи в игровую область Ui объекст и его текст
//------------------------------------------------------------------------------------------------------------------------------------------
namespace QuantumJourneys.Pages.Game.GameplayMeetingWithGod
{
    //--------------------------------------------------------------------------------------------------------------------------------------
    public class MeetingWithGodTextTransfer
    {
        //----------------------------------------------------------------------------------------------------------------------------------

        private int counter = 0;
        private List<string> textsList;

        //----------------------------------------------------------------------------------------------------------------------------------
        public MeetingWithGodTextTransfer()
        {
            InitLanguage();
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        private void InitLanguage()
        {
#if DEBUG
            MyLogger.logger.LogInformation("Начало инициализации языка для страницы игры.");
#endif
            switch (SelectLanguage.language)
            {
                case "Ru":
                    TextGame_Ru textList_Ru = new TextGame_Ru();
                    textsList = textList_Ru.SetTextGame();
                    break;

                case "En":
                    TextGame_En textList_En = new TextGame_En();
                    textsList = textList_En.SetTextGame();
                    break;

                default:
                    TextGame_En textList_Default = new TextGame_En();
                    textsList = textList_Default.SetTextGame();
                    break;
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        public StateGameUI GetStateUi()
        {
#if DEBUG
            MyLogger.logger.LogInformation($"Текущие состояние ui объекта - {textsList[counter]}.");
#endif
            if (counter < textsList.Count - 1 && textsList[counter].StartsWith("Text: ")) return StateGameUI.label;
            else if (counter < textsList.Count - 1 && textsList[counter].StartsWith("Button_two: ")) return StateGameUI.button_two;
            else if (counter < textsList.Count - 1 && textsList[counter].StartsWith("Button_four: ")) return StateGameUI.button_four;
            else if (counter < textsList.Count - 1 && textsList[counter].StartsWith("Img: ")) return StateGameUI.img;
            else if (counter < textsList.Count - 1 && textsList[counter].StartsWith("Audio: ")) return StateGameUI.audio;
            else if (counter < textsList.Count - 1 && textsList[counter].StartsWith("Audio_loop: ")) return StateGameUI.audio_loop;
            else if (counter < textsList.Count - 1 && textsList[counter].StartsWith("MiniGame: ")) { counter++; return StateGameUI.miniGame; }
            else if (counter < textsList.Count - 1 && textsList[counter] == "EndScene") return StateGameUI.endScene;
            else return StateGameUI.none;
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        public string GetLabelText()
        {
            string text = textsList[counter];
            counter++;
            return text.Substring("Text: ".Length);
        }
        public List<string> GetTwoButtonsText()
        {
            List<string> texts = new();

            for (int i = 0; i < 2; i++)
            {
                texts.Add(textsList[counter].Substring("Button_two: ".Length));
                counter++;
            }

            return texts;
        }
        public List<string> GetFourButtonsText()
        {
            List<string> texts = new();

            for (int i = 0; i < 4; i++)
            {
                texts.Add(textsList[counter].Substring("Button_four: ".Length));
                counter++;
            }

            return texts;
        }
        public string GetMainImg()
        {
            string imgName = textsList[counter];
            counter++;
            return imgName.Substring("Img: ".Length);
        }
        public string GetAudio()
        {
            string audioName = textsList[counter];
            counter++;

            if (audioName.StartsWith("Audio: ")) return audioName.Substring("Audio: ".Length);
            else return audioName.Substring("Audio_loop: ".Length);
        }
        //----------------------------------------------------------------------------------------------------------------------------------
    }
    //--------------------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------------------
