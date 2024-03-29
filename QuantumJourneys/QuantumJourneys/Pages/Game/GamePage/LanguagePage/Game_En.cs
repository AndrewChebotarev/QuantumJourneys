﻿//Английский язык для страницы "Игры"
//------------------------------------------------------------------------------------------------------------------------------------------
namespace QuantumJourneys.Pages.Game.Language
{
    //--------------------------------------------------------------------------------------------------------------------------------------
    public class Game_En
    {
        //----------------------------------------------------------------------------------------------------------------------------------
        public Game_En(GamePage gamePage) 
        {
            Button menuBtn = (Button)gamePage.FindByName("menuBtn");
            menuBtn.Text = "Menu";

#if DEBUG
            MyLogger.logger.LogInformation("Инициализация текста для UI английский - завершена.");
#endif
        }
        //----------------------------------------------------------------------------------------------------------------------------------
    }
    //--------------------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------------------
