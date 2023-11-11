//Текст для страницы MenuPage - русский
//--------------------------------------------------------------------------------------------------------------------------------------
namespace QuantumJourneys.Pages.Menu.Language
{
    //----------------------------------------------------------------------------------------------------------------------------------
    public class Menu_Ru
    {
        //------------------------------------------------------------------------------------------------------------------------------
        public Menu_Ru(MainPage mainPage)
        {
            Button SoloGameBtn = (Button)mainPage.FindByName("SoloGameBtn");
            SoloGameBtn.Text = "Одиночная игра";
            Button MultyGameBtn = (Button)mainPage.FindByName("MultyGameBtn");
            MultyGameBtn.Text = "Мультиплеерная игра";
            Button StatisticsBtn = (Button)mainPage.FindByName("StatisticsBtn");
            StatisticsBtn.Text = "Статистика";
            Button SettingsBtn = (Button)mainPage.FindByName("SettingsBtn");
            SettingsBtn.Text = "Настройки";
            Button ExitBtn = (Button)mainPage.FindByName("ExitBtn");
            ExitBtn.Text = "Выход";
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
    //----------------------------------------------------------------------------------------------------------------------------------
}
//--------------------------------------------------------------------------------------------------------------------------------------
