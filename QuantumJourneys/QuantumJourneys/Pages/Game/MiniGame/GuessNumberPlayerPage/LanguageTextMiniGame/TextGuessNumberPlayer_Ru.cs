﻿namespace QuantumJourneys.Pages.Game.MiniGame.GuessNumberPlayerPage.LanguageTextMiniGame
{
    public class TextGuessNumberPlayer_Ru
    {
        RandomText randomHelp = new();

        public List<string> SetTextGame()
        {
            return new List<string> 
            {

            "NameMiniGame: Игра: угадай божественное число",

            randomHelp.GetRandomText(randomText),

            ""

            };
        }

       private string[][] randomText =
       {
            //
            new string[]
            {
                "Text: (Бог, White)А мне вот интересно, сможешь ли ты угадать число, которое я загадаю? В голове у меня число от 1 до 100, можешь попробовать угадать его и написать мне.",
                "Text: (Бог, White)Хм, ну допустим, ты попробуешь отгадать мое число, я даже позволю тебе это делать. Я выбрал число от 1 до 100, угадай его, жду твоего ответа.",
                "Text: (Бог, White)Давай сыграем в угадай число, я могу поставить на него все свои божественные силы. Попробуй угадать число от 1 до 100, скажи свой вариант, я жду.",
                "Text: (Бог, White)Давай сыграем в угадай число, я могу поставить на него все свои божественные силы. Отгадай мое число от 1 до 100, скажи свое предположение, интересно, что у тебя получится.",
                "Text: (Бог, White)Ладно, давай поиграем в угадай число, но я предупреждаю, я не буду жалеть тех, кто не сможет угадать правильно. В голове у меня число от 1 до 100, попробуй угадать, жду твоего ответа.",
                "Text: (Бог, White)Моя очередь загадывать число, а твоя – отгадывать. Не промахнись, или будет очень плохо. Угадай число от 1 до 100, скажи мне свое предположение, я жду.",
                "Text: (Бог, White)Добро пожаловать в игру угадай число, где вы можете заполнить свой лишний разум. Жду от тебя ответ на вопрос: какое число от 1 до 100 я загадал?",
                "Text: (Бог, White)Пришло время потерять вашу надежду и угадать мое число в игре угадай число. Ваш разум так слаб, что я даже не думаю, что вы можете выиграть эту игру. У меня есть число от 1 до 100, твоя задача - угадать его, я буду ждать твой ответ.",
                "Text: (Бог, White)Люблю проводить время с земными игроками в пыхтение и угадай число — любимые игры бесполезных людей, которые забыли, что я обладаю всей мощью во вселенной. Назови число между 1 и 100, которое я задумал, и я буду ждать твоего ответа"
            }
        };
    }
}

