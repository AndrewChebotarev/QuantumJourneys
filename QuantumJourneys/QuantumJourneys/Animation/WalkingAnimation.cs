//Анимация открытия глаз и моргание
//----------------------------------------------------------------------------------------------------------------------------------
namespace QuantumJourneys.Animation
{
    //------------------------------------------------------------------------------------------------------------------------------
    public class WalkingAnimation
    {
        //--------------------------------------------------------------------------------------------------------------------------
        public async Task Animation(GamePage gamePage)
        {
            await EyeOpeningAnimation(gamePage);

            await Task.Delay(500);
            TransferBlack(gamePage);

            await BlinkAnimation(gamePage);
            await Task.Delay(500);
        }
        //--------------------------------------------------------------------------------------------------------------------------
        private async Task EyeOpeningAnimation(GamePage gamePage)
        {
            await Task.Delay(1500);

            gamePage.Background = Color.FromRgb(0, 0, 0);

            for (int i = 0; i < 256; i++)
            {
                gamePage.Background = Color.FromRgb(i, i, i);
                await Task.Delay(5);
            }
        }
        private async Task BlinkAnimation(GamePage gamePage)
        {
            await Task.Delay(500);
            TransferWhite(gamePage);

            await Task.Delay(500);
            TransferBlack(gamePage);
        }
        //--------------------------------------------------------------------------------------------------------------------------
        private void TransferWhite(GamePage gamePage)
        {
            gamePage.Background = Color.FromRgb(255, 255, 255);
        }
        private void TransferBlack(GamePage gamePage)
        {
            gamePage.Background = Color.FromRgb(0, 0, 0);
        }
        //--------------------------------------------------------------------------------------------------------------------------
        public async Task AnimationMainPic(Image ImageWindow)
        {
            for (double i = 0; i <= 1; i += 0.1)
            {
                ImageWindow.Opacity = i;
                await Task.Delay(40);
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------
        public async Task AnimationLabel(Label label)
        {
            for (double i = 0; i <= 1; i += 0.1)
            {
                label.Opacity = i;
                await Task.Delay(40);
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------
    }
    //------------------------------------------------------------------------------------------------------------------------------
}
//----------------------------------------------------------------------------------------------------------------------------------