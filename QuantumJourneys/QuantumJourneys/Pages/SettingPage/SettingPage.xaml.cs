namespace QuantumJourneys.Pages.SettingPage;

public partial class SettingPage : ContentPage
{
	public SettingPage()
	{
		InitializeComponent();
    }
    private async void SoloGameBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync(false);
    }
}