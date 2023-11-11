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
            Button LoadGameBtn = (Button)newOrLoadGameSoloPage.FindByName("LoadGameBtn");
            LoadGameBtn.Text = "Continue game";
            Button NewGameBtn = (Button)newOrLoadGameSoloPage.FindByName("NewGameBtn");
            NewGameBtn.Text = "New adventure";
            Button BacktBtn = (Button)newOrLoadGameSoloPage.FindByName("BacktBtn");
            BacktBtn.Text = "Back";
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
    //----------------------------------------------------------------------------------------------------------------------------------
}
//--------------------------------------------------------------------------------------------------------------------------------------