﻿//Русский язык для страницы выбора новой/загрузка игры
//--------------------------------------------------------------------------------------------------------------------------------------
namespace QuantumJourneys.Pages.NewOrLoadGameSolo.Language
{
    //----------------------------------------------------------------------------------------------------------------------------------
    public class NewOrLoadGameSolo_Ru
    {
        //------------------------------------------------------------------------------------------------------------------------------
        public NewOrLoadGameSolo_Ru(NewOrLoadGameSoloPage newOrLoadGameSoloPage)
        {
            Button LoadGameBtn = (Button)newOrLoadGameSoloPage.FindByName("LoadGameBtn");
            LoadGameBtn.Text = "Продолжить игру";
            Button NewGameBtn = (Button)newOrLoadGameSoloPage.FindByName("NewGameBtn");
            NewGameBtn.Text = "Новое приключение";
            Button BacktBtn = (Button)newOrLoadGameSoloPage.FindByName("BacktBtn");
            BacktBtn.Text = "Назад";

#if DEBUG
            MyLogger.logger.LogInformation("Инициализация текста для UI русский - завершена.");
#endif
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
    //----------------------------------------------------------------------------------------------------------------------------------
}
//--------------------------------------------------------------------------------------------------------------------------------------
