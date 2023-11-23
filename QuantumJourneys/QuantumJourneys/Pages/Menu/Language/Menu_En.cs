//Текст для страницы MenuPage - английский
//--------------------------------------------------------------------------------------------------------------------------------------
namespace QuantumJourneys.Pages.Menu.Language
{
    //----------------------------------------------------------------------------------------------------------------------------------
    public class Menu_En
    {
        //------------------------------------------------------------------------------------------------------------------------------
        public Menu_En(MainPage mainPage) 
        {
            Button SoloGameBtn = (Button)mainPage.FindByName("SoloGameBtn");
            SoloGameBtn.Text = "Single player";
            Button MultyGameBtn = (Button)mainPage.FindByName("MultyGameBtn");
            MultyGameBtn.Text = "Multiplayer";
            Button StatisticsBtn = (Button)mainPage.FindByName("StatisticsBtn");
            StatisticsBtn.Text = "Statistics";
            Button SettingsBtn = (Button)mainPage.FindByName("SettingsBtn");
            SettingsBtn.Text = "Settings";
            Button ExitBtn = (Button)mainPage.FindByName("ExitBtn");
            ExitBtn.Text = "Exit";
#if DEBUG
            MyLogger.logger.LogInformation("Инициализация текста для UI английский - завершена.");
#endif
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
    //----------------------------------------------------------------------------------------------------------------------------------
}
//--------------------------------------------------------------------------------------------------------------------------------------
