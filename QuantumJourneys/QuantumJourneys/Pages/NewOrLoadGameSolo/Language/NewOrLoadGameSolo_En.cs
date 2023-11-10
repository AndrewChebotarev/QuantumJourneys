//Английский язык для страницы выбора новой/загрузка игры
//--------------------------------------------------------------------------------------------------------------------------------------
namespace QuantumJourneys.Pages.NewOrLoadGameSolo.Language
{
    //----------------------------------------------------------------------------------------------------------------------------------
    public class NewOrLoadGameSolo_En
    {
        //------------------------------------------------------------------------------------------------------------------------------
        public NewOrLoadGameSolo_En(NewOrLoadGameSoloPage newOrLoadGameSoloPage)
        {
            Button NewGameBtn = (Button)newOrLoadGameSoloPage.FindByName("NewGameBtn");
            NewGameBtn.Text = "New adventure";
            Button LoadGameBtn = (Button)newOrLoadGameSoloPage.FindByName("LoadGameBtn");
            LoadGameBtn.Text = "Load game";
            Button BacktBtn = (Button)newOrLoadGameSoloPage.FindByName("BacktBtn");
            BacktBtn.Text = "Back";
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
    //----------------------------------------------------------------------------------------------------------------------------------
}
//--------------------------------------------------------------------------------------------------------------------------------------