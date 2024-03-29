﻿//Русский язык для страницы миниигры - Угадай число (игрок)
//------------------------------------------------------------------------------------------------------------------------------------------
namespace QuantumJourneys.Pages.MiniGame.GuessNumberPlayerPage.Language
{
    //--------------------------------------------------------------------------------------------------------------------------------------
    public class GuessNumberPlayer_Ru
    {
        //----------------------------------------------------------------------------------------------------------------------------------
        public GuessNumberPlayer_Ru(GuessNumberPlayer guessNumberPlayer) 
        {
            Button menuBtn = (Button)guessNumberPlayer.FindByName("menuBtn");
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
