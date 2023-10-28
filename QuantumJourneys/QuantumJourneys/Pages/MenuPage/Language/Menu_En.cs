//Текст для страницы MenuPage - английский
//--------------------------------------------------------------------------------------------------------------------------------------
namespace QuantumJourneys.Pages.MenuPage.Language
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
            Button SettingBtn = (Button)mainPage.FindByName("SettingBtn");
            SettingBtn.Text = "Setting";
            Button ExitBtn = (Button)mainPage.FindByName("ExitBtn");
            ExitBtn.Text = "Exit";
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
    //----------------------------------------------------------------------------------------------------------------------------------
}
//--------------------------------------------------------------------------------------------------------------------------------------
