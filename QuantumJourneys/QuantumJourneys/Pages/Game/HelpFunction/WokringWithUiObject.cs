//Класс для передачи в игровую область Ui объекст и его текст
//------------------------------------------------------------------------------------------------------------------------------------------
using QuantumJourneys.Pages.Game.MiniGame.GuessNumberPlayerPage.LanguageTextMiniGame;

namespace QuantumJourneys.Pages.Game.GameplayMeetingWithGod
{
    //--------------------------------------------------------------------------------------------------------------------------------------
    public class WokringWithUiObject
    {
        //----------------------------------------------------------------------------------------------------------------------------------

        private int counter = 0;
        private List<string> textsList;

        //----------------------------------------------------------------------------------------------------------------------------------
        public WokringWithUiObject()
        {
            SelectNewLocationStateGameplay();
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        private void SelectNewLocationStateGameplay()
        {
            if (LocationStateGameplay.locationStateGameplay == "GameMeetingWithGod") InitLanguageMeetingWithGod();
            else if (LocationStateGameplay.locationStateGameplay == "MiniGameGuessNumberPlayer") InitLanguageMiniGameNumberPlayer();
        }
        private void InitLanguageMeetingWithGod()
        {
#if DEBUG
            MyLogger.logger.LogInformation("Начало инициализации языка для страницы игры.");
#endif
            switch (SelectLanguage.language)
            {
                case "Ru":
                    TextMeetingWithGod_Ru textMeetingWithGod_Ru = new TextMeetingWithGod_Ru();
                    textsList = textMeetingWithGod_Ru.SetTextGame();
                    break;

                case "En":
                    TextMeetingWithGod_En textMeetingWithGod_En = new TextMeetingWithGod_En();
                    textsList = textMeetingWithGod_En.SetTextGame();
                    break;

                default:
                    TextMeetingWithGod_En textList_Default = new TextMeetingWithGod_En();
                    textsList = textList_Default.SetTextGame();
                    break;
            }
        }
        private void InitLanguageMiniGameNumberPlayer()
        {
#if DEBUG
            MyLogger.logger.LogInformation("Начало инициализации языка для страницы миниигры - угадай число (игрок).");
#endif
            switch (SelectLanguage.language)
            {
                case "Ru":
                    TextGuessNumberPlayer_Ru textMeetingWithGod_Ru = new TextGuessNumberPlayer_Ru();
                    textsList = textMeetingWithGod_Ru.SetTextGame();
                    break;

                case "En":
                    TextGuessNumberPlayer_En textMeetingWithGod_En = new TextGuessNumberPlayer_En();
                    textsList = textMeetingWithGod_En.SetTextGame();
                    break;

                default:
                    TextGuessNumberPlayer_En textList_Default = new TextGuessNumberPlayer_En();
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
            else if (counter < textsList.Count - 1 && textsList[counter].StartsWith("NameMiniGame: ")) return StateGameUI.nameMiniGame;
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
        public string GetNameNameMiniGame()
        {
            string text = textsList[counter];
            counter++;
            return text.Substring("NameMiniGame: ".Length);
        }
        //----------------------------------------------------------------------------------------------------------------------------------
    }
    //--------------------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------------------
