//Класс для реализации основной игры
//------------------------------------------------------------------------------------------------------------------------------

namespace QuantumJourneys.Pages.Game;

//------------------------------------------------------------------------------------------------------------------------------
public partial class GamePage : ContentPage
{

    WalkingAnimation walkingAnimation;
    CharacterCreationPage characterCreationPage;

    //--------------------------------------------------------------------------------------------------------------------------
    public GamePage(CharacterCreationPage characterCreationPage)
	{
        InitializeComponent();
        this.characterCreationPage = characterCreationPage;
        Task task = InitAsync();
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async Task InitAsync()
    {
        await WalkingAnimation();
        await InitWhiteMainPic();
        await CreateNewLabel();
        InitSpaceForClick();
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async Task WalkingAnimation()
    {
        WalkingAnimation walkingAnimation = new();
        this.walkingAnimation = walkingAnimation;
        await walkingAnimation.Animation(this);
    }
    private async Task InitWhiteMainPic()
    {
        ImageWindow.Source = "whitebackground.png";
        await walkingAnimation.AnimationMainPic(ImageWindow);
    }
    private void InitSpaceForClick()
    {
        TapGestureRecognizer tapGesture = new();
        tapGesture.Tapped += async (s, e) =>
        {
            await CreateNewLabel();
        };

        SpaceForClickFirst.GestureRecognizers.Add(tapGesture);
        SpaceForClickSecond.GestureRecognizers.Add(tapGesture);
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async Task CreateNewLabel()
    {
        Label label = CreateLabel();
        await walkingAnimation.AnimationLabel(label);
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private Label CreateLabel()
    {
        Label label = new()
        {
            VerticalOptions = LayoutOptions.Start,
            Opacity = 0,
            FontSize = 20,
            Text = "fadsgsgsgsgsgsgsgsgsgsgsgsg"
        };

        SpaceForClickSecond.Add(label);

        return label;
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private void AudioBtn_Clicked(object sender, EventArgs e)
    {
        if (AudioBtn.Text == "🔊")
        {
            AudioBtn.Text = "🔇";
        }
        else
        {
            AudioBtn.Text = "🔊";
        }
    }
    //--------------------------------------------------------------------------------------------------------------------------
    private async void BackBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
    //--------------------------------------------------------------------------------------------------------------------------
    protected async override void OnDisappearing()
    {
        base.OnDisappearing();
        await characterCreationPage.BackGamePage();
    }
    //--------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------