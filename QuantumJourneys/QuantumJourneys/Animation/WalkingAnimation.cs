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
#if DEBUG
            MyLogger.logger.LogInformation("Анимация открытия глаз - начата.");
#endif
            await EyeOpeningAnimation(gamePage);

            await Task.Delay(500);
            TransferBlack(gamePage);

            await BlinkAnimation(gamePage);
            await Task.Delay(500);
#if DEBUG
            MyLogger.logger.LogInformation("Анимация открытия глаз - конец.");
#endif
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
        public async Task AnimationAppearanceMainPic(Image ImageWindow)
        {
#if DEBUG
            MyLogger.logger.LogInformation("Анимация плавного показа главной картинки - начата.");
#endif
            for (double i = 0; i <= 1; i += 0.1)
            {
                ImageWindow.Opacity = i;
                await Task.Delay(40);
            }
#if DEBUG
            MyLogger.logger.LogInformation("Анимация плавного показа главной картинки - конец.");
#endif
        }
        public async Task AnimationBlackoutMainPic(Image ImageWindow)
        {
#if DEBUG
            MyLogger.logger.LogInformation("Анимация плавного затемнения главной картинки - начата.");
#endif
            for (double i = 1; i > 0; i -= 0.1)
            {
                ImageWindow.Opacity = i;
                await Task.Delay(40);
            }
#if DEBUG
            MyLogger.logger.LogInformation("Анимация плавного затемнения главной картинки - конец.");
#endif
        }
        //--------------------------------------------------------------------------------------------------------------------------
        public async Task AnimationLabel(Label label)
        {
#if DEBUG
            MyLogger.logger.LogInformation("Анимация плавного показа нового текста - начата.");
#endif
            for (double i = 0; i <= 1; i += 0.1)
            {
                label.Opacity = i;
                await Task.Delay(40);
            }
#if DEBUG
            MyLogger.logger.LogInformation("Анимация плавного показа нового текста - конец.");
#endif
        }
        //--------------------------------------------------------------------------------------------------------------------------
        public async Task AnimationButton(Button button)
        {
#if DEBUG 
            MyLogger.logger.LogInformation("Анимация плавного показа нового текста - начата.");
#endif
            for (double i = 0; i <= 1;i += 0.1)
            {
                button.Opacity = i;
                await Task.Delay(40);
            }
#if DEBUG
            MyLogger.logger.LogInformation("Анимация плавного показа нового текста - конец.");
#endif
        }
        //--------------------------------------------------------------------------------------------------------------------------
        public async Task AnimationEntry(Entry entry)
        {
#if DEBUG
            MyLogger.logger.LogInformation("Анимация плавного показа нового текста - начата.");
#endif
            for (double i = 0; i <= 1; i += 0.1)
            {
                entry.Opacity = i;
                await Task.Delay(40);
            }
#if DEBUG
            MyLogger.logger.LogInformation("Анимация плавного показа нового текста - конец.");
#endif
        }
        //--------------------------------------------------------------------------------------------------------------------------
    }
    //------------------------------------------------------------------------------------------------------------------------------
}
//----------------------------------------------------------------------------------------------------------------------------------