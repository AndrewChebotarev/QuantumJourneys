﻿//Русский язык для страницы "Игры"
//------------------------------------------------------------------------------------------------------------------------------------------
namespace QuantumJourneys.Pages.Game.Language
{
    //--------------------------------------------------------------------------------------------------------------------------------------
    public class Game_Ru
    {
        //----------------------------------------------------------------------------------------------------------------------------------
        public Game_Ru(GamePage gamePage)
        {
            Button menuBtn = (Button)gamePage.FindByName("menuBtn");
            menuBtn.Text = "Меню";

#if DEBUG
            MyLogger.logger.LogInformation("Инициализация текста для UI русский - завершена.");
#endif
        }
        //----------------------------------------------------------------------------------------------------------------------------------
    }
    //--------------------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------------------